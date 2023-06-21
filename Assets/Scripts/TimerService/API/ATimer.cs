using System;

namespace TimerService.API
{
    public abstract class ATimer : ITimer
    {
        public float ElapsedTime { get; protected set; }
        
        protected bool IsRunning = false;
        protected float TimerIntervalCounter = 0f;
        protected const float TimerInterval = 1f;
        
        public abstract event Action<int> OnTimerTick;
        public abstract void Tick();

        public void Start()
        {
            IsRunning = true;
        }

        public void Stop()
        {
            IsRunning = false;
        }

        public void Reset()
        {
            ElapsedTime = 0;
        }
    }
}