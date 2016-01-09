using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Avanade.SmartApps.Logger
{
    class SaveAsynchronous
    {
        private class SyncEvents : IDisposable
        {
            private AutoResetEvent _newItemEvent;
            private ManualResetEvent _exitThreadEvent;
            private WaitHandle[] _eventArray;

            public SyncEvents()
            {
                _newItemEvent = new AutoResetEvent(false);
                _exitThreadEvent = new ManualResetEvent(false);
                _eventArray = new WaitHandle[2];
                _eventArray[0] = _newItemEvent;
                _eventArray[1] = _exitThreadEvent;
            }

            public void SetExitThreadEvent()
            {
                _exitThreadEvent.Set();
            }

            public void ResetExitThreadEvent()
            {
                _exitThreadEvent.Reset();
            }

            public void SetNewItemEvent()
            {
                _newItemEvent.Set();
            }

            public void WaitForAnyEvent()
            {
                WaitHandle.WaitAny(_eventArray);
            }

            public bool CheckExitEvent()
            {
                return _exitThreadEvent.WaitOne(0, false);
            }

            public void Dispose()
            {
                _newItemEvent.Close();
                _exitThreadEvent.Close();

                _eventArray = null;
                _newItemEvent = null;
                _exitThreadEvent = null;
            }
        }

        public delegate void ConsumeDelegate(object item);

        private ConsumeDelegate _consumeMethod;
        private Queue _queue;
        private SyncEvents _syncEvents;
        private Thread _consumerThread;
        private ThreadPriority _threadPriority;
        private string _threadName;
        private Timer tempo;

        public SaveAsynchronous(ConsumeDelegate consumeMethod, string threadName, ThreadPriority threadPriority, bool autoStart)
        {
            if (consumeMethod == null) throw new ArgumentNullException("consumeMethod");

            _consumeMethod = consumeMethod;
            _queue = Queue.Synchronized(new Queue());
            _syncEvents = new SyncEvents();
            _threadPriority = threadPriority;
            _threadName = threadName;

            ExecutionTime();

            if (autoStart) Start();
        }

        private void ExecutionTime()
        {
            if (tempo == null)
            {
                Object objeto = new object();
                tempo = new Timer(TimerTask, objeto, 10000, 10000);
            }
        }

        private void TimerTask(object StateObj)
        {
            _syncEvents.SetNewItemEvent();
        }

        private void ThreadRun()
        {
            while (true)
            {
                _syncEvents.WaitForAnyEvent();

                while (_queue.Count > 0)
                {
                    if (_syncEvents.CheckExitEvent()) break;

                    _consumeMethod.Invoke(_queue.Dequeue());
                }

                if (_syncEvents.CheckExitEvent()) break;
            }
        }

        private void Start()
        {
            if (_consumerThread != null && _consumerThread.IsAlive) return;

            _consumerThread = new Thread(new ThreadStart(ThreadRun));

            if (_threadName != null) _consumerThread.Name = _threadName;

            _consumerThread.Priority = _threadPriority;
            _syncEvents.ResetExitThreadEvent();
            _consumerThread.Start();
        }

        private void Stop()
        {
            if (_consumerThread != null && _consumerThread.IsAlive)
            {
                _syncEvents.SetExitThreadEvent();
                _consumerThread.Join();
            }
            _consumerThread = null;
            _queue.Clear();
        }

        public void Finish()
        {
            Stop();
        }

        public bool Save(object o)
        {
            if (CheckExitEvent()) return false;

            _queue.Enqueue(o);
            if (_queue.Count >= 10)
            {
                _syncEvents.SetNewItemEvent();
            }
            return true;
        }

        public bool CheckExitEvent()
        {
            return _syncEvents.CheckExitEvent();
        }
    }
}
