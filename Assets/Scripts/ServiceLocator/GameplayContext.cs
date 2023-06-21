using Models;

namespace ServiceLocator
{
    public class GameplayContext : DIContainer
    {
        private void Awake()
        {
            Register(new GameplayModel());
            Register(new EnemiesModel());
        }
    }
}