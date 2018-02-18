using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Jurassic;
using Jurassic.Library;
using ActionLanguage;
using EliteDangerousCore;

namespace EDDiscovery.ModApi.Javascript
{
    public class JavascriptController : IDisposable
    {
        private class QueueProcessorArgs
        {
            public ActionCoreController Controller;
            public HistoryList History;
            public string ConfigPrefix;
            public string ScriptFile;
            public string ScriptString;
        }

        private class ScriptEnvironment
        {
            public JournalInstance Journal;
            public AudioInstance Audio;
            public HistoryInstance History;
            public ConfigInstance Config;
        }

        private ConcurrentQueue<Action<ScriptEnvironment>> ActionQueue = new ConcurrentQueue<Action<ScriptEnvironment>>();
        private AutoResetEvent NewActionEvent = new AutoResetEvent(false);
        private ManualResetEvent ExitRequestedEvent = new ManualResetEvent(false);
        private QueueProcessorArgs ProcessorArgs;
        private Thread ProcessorThread;
        private int running;

        public JavascriptController(ActionCoreController actionController, HistoryList history, string configPrefix)
        {
            ProcessorArgs = new QueueProcessorArgs
            {
                Controller = actionController,
                History = history,
                ConfigPrefix = configPrefix
            };
        }

        private void QueueProcessor(object args)
        {
            QueueProcessor((QueueProcessorArgs)args);
        }

        private void QueueProcessor(QueueProcessorArgs args)
        {
            running = 1;
            try
            {
                AutoResetEvent newActionEvent = NewActionEvent;
                ManualResetEvent exitRequestedEvent = ExitRequestedEvent;
                ConcurrentQueue<Action<ScriptEnvironment>> actionQueue = ActionQueue;

                ScriptEngine engine = new ScriptEngine();
                ScriptEnvironment env = new ScriptEnvironment
                {
                    Journal = new JournalInstance(engine),
                    Audio = new AudioInstance(engine, args.Controller),
                    History = new HistoryInstance(engine, args.History),
                    Config = new ConfigInstance(engine, args.ConfigPrefix)
                };

                engine.SetGlobalValue("Journal", env.Journal);
                engine.SetGlobalValue("Audio", env.Audio);
                engine.SetGlobalValue("History", env.History);
                engine.SetGlobalValue("Config", env.Config);

                if (args.ScriptString != null)
                {
                    engine.Execute(new StringScriptSource(args.ScriptString));
                }

                if (args.ScriptFile != null)
                {
                    engine.Execute(new FileScriptSource(args.ScriptFile));
                }

                while (!exitRequestedEvent.WaitOne(0))
                {
                    switch (WaitHandle.WaitAny(new WaitHandle[] { exitRequestedEvent, newActionEvent }))
                    {
                        case 0:
                            return;
                        case 1:
                            while (actionQueue.Count != 0)
                            {
                                Action<ScriptEnvironment> act;
                                if (exitRequestedEvent.WaitOne(0))
                                    return;
                                if (actionQueue.TryDequeue(out act))
                                {
                                    act(env);
                                }
                            }
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine($"Exception caught in Javascript processor: {ex.ToString()}");
            }
            finally
            {
                running = 0;
            }
        }

        private void Enqueue(Action<ScriptEnvironment> act)
        {
            ManualResetEvent stopRequested = ExitRequestedEvent;
            if (stopRequested == null || stopRequested.WaitOne(0))
                return;

            ActionQueue.Enqueue(act);
            NewActionEvent.Set();

            if (Interlocked.CompareExchange(ref running, 1, 0) == 0)
            {
                ProcessorThread = new Thread(new ParameterizedThreadStart(QueueProcessor))
                {
                    Name = $"Javascript Processor ({ProcessorArgs.ConfigPrefix})",
                    IsBackground = true
                };

                ProcessorThread.Start(ProcessorArgs);
            }
        }

        public void OnNewJournalEntry(JournalEntry je)
        {
            Enqueue(e => e.Journal.OnNewJournalEntry(je));
        }

        public void OnNewHistoryEntry(HistoryEntry he)
        {
            Enqueue(e => e.History.OnNewHistoryEntry(he));
        }

        public void OnRefresh(HistoryList hl)
        {
            Enqueue(e =>
            {
                e.History.OnRefresh(hl);
                e.Journal.OnRefresh(hl);
            });
        }

        public void Stop()
        {
            if (ExitRequestedEvent != null)
            {
                ExitRequestedEvent.Set();
                ExitRequestedEvent = null;
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }

        protected void Dispose(bool disposing)
        {
            Stop();
        }
    }
}
