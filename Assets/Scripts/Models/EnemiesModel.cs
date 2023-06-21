using System;

namespace Models
{
    public class EnemiesModel
    {
        public event Action EnemiesSpeedChanged;
        public float EnemiesSpeed => _enemiesSpeed;
        public float SpawnDuration => _spawnDuration;
        
        private float _enemiesSpeed = 2f;
        private float _spawnDuration = 5f;

        public void SetEnemiesSpeed(float speed)
        {
            _enemiesSpeed = speed;
            EnemiesSpeedChanged?.Invoke();
        }

        public void SetSpawnDuration(float duration)
        {
            _spawnDuration = duration;
        }
    }
    
}