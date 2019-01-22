
namespace ServerSide.Timing
{
    using System;
    using System.Collections.Generic;
    using System.Threading;

    using ServerSide.Interfaces;
    using ServerSide.Servicing;

    public class TimeObserver : ITimeObserver, IProcess
    {
        private List<(Timer callBack, DateTime birthDay)> _calls;

        private delegate void method();

        private bool _isActive;

        private bool _isWorking;

        public event TimeEventHandler ChangeState = delegate { };

        public bool IsActive => _isActive;

        public void Start()
        {
            _isActive = true;
            var timeObserverThread = new Thread(Observe) { Name = "Поток работы таймера" };
            ChangeState(this, new TimeEventArgs("Таймер запущен"));
            timeObserverThread.Start();
        }

        public void Add((Timer callBack, DateTime birthDay) birthMethod)
        {
            _calls.Add(birthMethod);
        }

        public void Remove()
        {
          _calls.Remove();
        }

        public void End()
        {
            _isActive = false;
            _calls.Clear();
            while (_isWorking)
            {
                ChangeState(this, new TimeEventArgs("Ожидание завершения работы таймера..."));
                Thread.Sleep(500);
            }

            ChangeState(this, new TimeEventArgs("Таймер выключен"));
        }

        private void Observe()
        {
            _isWorking = true;
            while (_isActive)
            {
                //if (Math.Abs(_timeFrame.Day - DateTime.Today.Day) > 0)
                //{
                //    _timeFrame = DateTime.Today;
                //    ChangeState(this, new TimeEventArgs(true));
                //}

                Thread.Sleep(1000);
            }

            _isWorking = false;
        }
    }
}