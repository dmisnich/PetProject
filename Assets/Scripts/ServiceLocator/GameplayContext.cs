using Models;
using TimerService.API;
using TimerService.Impl;

namespace ServiceLocator
{
    public class GameplayContext : DIContainer
    {
        private void Awake()
        {
            Register(new GameplayModel());
            Register(new EnemiesModel());
            Register(new EnemiesModel());
            RegisterTimer();
        }

        private void RegisterTimer()
        {
            ATimer timer = new BaseTimer();
            Register(timer);
        }
    }
}