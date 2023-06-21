using System;

namespace TimerService.API
{
    public interface ITimer
    {
        event Action<int> OnTimerTick;
        void Tick();
        void Start();
        void Stop();
        void Reset();
    }
}