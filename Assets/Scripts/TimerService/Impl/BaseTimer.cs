using System;
using TimerService.API;
using UnityEngine;

namespace TimerService.Impl
{
    public class BaseTimer : ATimer
    {
        public override event Action<int> OnTimerTick;
        
        public override void Tick()
        {
            if (IsRunning)
            {
                ElapsedTime += Time.deltaTime;
                TimerIntervalCounter += Time.deltaTime;
                if (TimerIntervalCounter >= TimerInterval)
                {
                    TimerIntervalCounter = 0f;
                    OnTimerTick?.Invoke((int)ElapsedTime);
                }
            }
        }
    }
}