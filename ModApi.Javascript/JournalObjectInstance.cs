using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Jurassic;
using Jurassic.Library;
using EliteDangerousCore;

namespace EDDiscovery.ModApi.Javascript
{
    public class JournalObjectInstance<T> : ObjectInstance
    {
        private static ConcurrentDictionary<Type, Action<JournalObjectInstance<T>, T>> PropertyPopulators = new ConcurrentDictionary<Type, Action<JournalObjectInstance<T>, T>>();
        protected static HashSet<string> ExcludeProperties { get; set; } = new HashSet<string>();
        protected static JournalObjectInstance<T> ObjectPrototype { get; set; }

        public JournalObjectInstance(ScriptEngine engine) : base(engine.Object.InstancePrototype)
        {
            this.PopulateFunctions();
        }

        public JournalObjectInstance(JournalObjectInstance<T> prototype, T val) : base(prototype)
        {
            var populator = PropertyPopulators.GetOrAdd(val.GetType(), t => GetPopulator(t));
            populator(this, val);
        }

        public static JournalObjectInstance<T> Create(ScriptEngine engine, T val)
        {
            if (ObjectPrototype == null)
            {
                ObjectPrototype = new JournalObjectInstance<T>(engine);
            }

            return new JournalObjectInstance<T>(ObjectPrototype, val);
        }

        #region Conversion builders
        private static Action<JournalObjectInstance<T>, T> GetPopulator(Type type)
        {
            PropertyInfo[] properties = type.GetProperties(BindingFlags.Instance | BindingFlags.Public);
            ParameterExpression jiexpr = Expression.Parameter(typeof(JournalObjectInstance<T>), "ji");
            ParameterExpression jeexpr = Expression.Parameter(typeof(T), "je");
            Expression jtexpr = Expression.Convert(jeexpr, type);

            MethodInfo addpropmi = GetMethodInfo<Action<JournalObjectInstance<T>, string, PropertyDescriptor, bool>>((ji, n, pd, x) => ji.DefineProperty(n, pd, x));
            ConstructorInfo makepdci = GetConstructorInfo<Func<object, Jurassic.Library.PropertyAttributes, PropertyDescriptor>>((o, pa) => new PropertyDescriptor(o, pa));
            List<Expression> calls = new List<Expression>();
            ConstantExpression flagsexpr = Expression.Constant(Jurassic.Library.PropertyAttributes.Sealed);
            ConstantExpression throwexpr = Expression.Constant(false);

            foreach (var prop in properties)
            {
                if (!ExcludeProperties.Contains(prop.Name))
                {
                    MemberExpression jepropexpr = Expression.MakeMemberAccess(jtexpr, prop);
                    ConstantExpression nameexpr = Expression.Constant(prop.Name);
                    Expression valexpr = null;

                    if (prop.PropertyType.IsPrimitive || prop.PropertyType.IsEnum || prop.PropertyType == typeof(string))
                    {
                        valexpr = jepropexpr;
                    }
                    else if (typeof(IDictionary).IsAssignableFrom(prop.PropertyType))
                    {
                        valexpr = GetDictEnumerator(jiexpr, jepropexpr);
                    }
                    else if (typeof(IEnumerable).IsAssignableFrom(prop.PropertyType))
                    {
                        valexpr = GetEnumerableEnumerator(jiexpr, jepropexpr);
                    }

                    if (valexpr != null)
                    {
                        NewExpression pdexpr = Expression.New(makepdci, jepropexpr, flagsexpr);
                        MethodCallExpression addpropexpr = Expression.Call(jiexpr, addpropmi, nameexpr, pdexpr, throwexpr);
                        calls.Add(addpropexpr);
                    }
                }
            }

            BlockExpression blockexpr = Expression.Block(calls.ToArray());
            Expression<Action<JournalObjectInstance<T>, T>> lambda = Expression.Lambda<Action<JournalObjectInstance<T>, T>>(blockexpr, jiexpr, jeexpr);
            return lambda.Compile();
        }

        private static MethodInfo GetMethodInfo<TDelegate>(Expression<TDelegate> expr)
        {
            return ((MethodCallExpression)expr.Body).Method;
        }

        private static ConstructorInfo GetConstructorInfo<TDelegate>(Expression<TDelegate> expr)
        {
            return ((NewExpression)expr.Body).Constructor;
        }

        private static MemberInfo GetMemberInfo<TDelegate>(Expression<TDelegate> expr)
        {
            return ((MemberExpression)expr.Body).Member;
        }

        private static Expression GetDictEnumerator(Expression jiexpr, Expression member)
        {
            Type type = member.Type;

            if (!type.IsGenericType || type.GetGenericArguments().Length != 2)
            {
                foreach (Type itype in type.GetInterfaces())
                {
                    if (itype.IsGenericType && itype.Name == "IEnumerable`1" && itype.GetGenericArguments()[0].Name == "KeyValuePair`2")
                    {
                        type = itype;
                        break;
                    }
                }
            }

            if (type.IsGenericType)
            {
                Type[] typeargs = type.GetGenericArguments();
                if (typeargs.Length == 1 && typeargs[0].Name == "KeyValuePair`2")
                {
                    typeargs = typeargs[0].GetGenericArguments();
                }

                if (typeargs.Length == 2 && typeargs[0] == typeof(string) && (typeargs[1].IsPrimitive || typeargs[1] == typeof(string)))
                {
                    MethodInfo enummi = GetMethodInfo<Func<JournalObjectInstance<T>, IEnumerable<KeyValuePair<string, object>>, ObjectInstance>>((ji, d) => ji.EnumPrimitiveDictionary(d));
                    enummi = enummi.GetGenericMethodDefinition().MakeGenericMethod(typeargs);
                    return Expression.Call(jiexpr, enummi, member);
                }
            }

            return Expression.Constant(null);
        }

        private static Expression GetEnumerableEnumerator(Expression jiexpr, Expression member)
        {
            Type type = member.Type;

            if (!type.IsGenericType || type.GetGenericArguments().Length != 1)
            {
                foreach (Type itype in type.GetInterfaces())
                {
                    if (itype.IsGenericType && itype.Name == "IEnumerable`1")
                    {
                        type = itype;
                        break;
                    }
                }
            }

            if (type.IsGenericType)
            {
                Type[] typeargs = type.GetGenericArguments();

                if (typeargs.Length == 1)
                {
                    if (typeargs[0].IsPrimitive || typeargs[0].IsEnum || typeargs[0] == typeof(string))
                    {
                        MethodInfo enummi = GetMethodInfo<Func<JournalObjectInstance<T>, IEnumerable<object>, ObjectInstance>>((ji, d) => ji.EnumPrimitiveArray(d));
                        enummi = enummi.GetGenericMethodDefinition().MakeGenericMethod(typeargs);
                        return Expression.Call(jiexpr, enummi, member);
                    }
                    else
                    {
                        MethodInfo enummi = GetMethodInfo<Func<JournalObjectInstance<T>, IEnumerable<object>, ObjectInstance>>((ji, d) => ji.EnumObjectArray(d));
                        enummi = enummi.GetGenericMethodDefinition().MakeGenericMethod(typeargs);
                        return Expression.Call(jiexpr, enummi, member);
                    }
                }
            }

            return Expression.Constant(null);
        }

        private ObjectInstance EnumPrimitiveDictionary<TVal>(IEnumerable<KeyValuePair<string, TVal>> dict)
        {
            ObjectInstance oinst = Engine.Object.Construct();

            foreach (var kvp in dict)
            {
                oinst[kvp.Key] = kvp.Value;
            }

            return oinst;
        }

        private ArrayInstance EnumPrimitiveArray<TVal>(IEnumerable<TVal> vals)
        {
            return Engine.Array.Construct(vals.ToArray());
        }

        private ArrayInstance EnumObjectArray<TVal>(IEnumerable<TVal> vals)
        {
            return Engine.Array.Construct(vals.Select(v => JournalObjectInstance<TVal>.Create(Engine, v)).ToArray());
        }
        #endregion
    }
}
