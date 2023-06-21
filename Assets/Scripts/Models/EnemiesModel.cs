using System;
using Random = UnityEngine.Random;

namespace Models
{
    public class EnemiesModel
    {
        public event Action EnemiesSpeedChanged;
        public float EnemiesSpeed => _enemiesSpeed;
        public int SpawnDuration => _spawnDuration;
        
        private float _enemiesSpeed = 1;
        private int _spawnDuration = 1;

        public void SetEnemiesSpeed(float speed)
        {
            _enemiesSpeed = speed + GetRandomSpeedHelper();
            EnemiesSpeedChanged?.Invoke();
        }

        public void SetSpawnDuration(int duration)
        {
            _spawnDuration = duration;
        }

        private float GetRandomSpeedHelper()
        {
            return Random.Range(-0.5f, 0.5f);
        }
    }
    
}