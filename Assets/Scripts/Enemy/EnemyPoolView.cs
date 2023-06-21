using System.Collections.Generic;
using Models;
using ServiceLocator;
using SpawnService;
using TimerService.API;
using TimerService.Impl;
using UnityEngine;

namespace Enemy
{
    public class EnemyPoolView : ASpawner
    {
        [SerializeField] private EnemyView enemyViewPrefab;
        [SerializeField] private Transform target;

        private EnemiesModel _enemiesModel;
        private GameplayModel _gameplayModel;
        private ATimer _timer = new BaseTimer();
        private List<EnemyView> _enemies = new List<EnemyView>();

        private void Start()
        {
            _enemiesModel = DIContainer.Resolve<EnemiesModel>();
            _gameplayModel = DIContainer.Resolve<GameplayModel>();
            _timer.OnTimerTick += OnTimerTick;
            _gameplayModel.OnGameStarted += StartSpawn;
        }

        private void OnDestroy()
        {
            _timer.OnTimerTick -= OnTimerTick;
            _gameplayModel.OnGameStarted -= StartSpawn;
        }

        private void Update()
        {
            _timer.Tick();
        }

        private void OnTimerTick(int time)
        {
            if (time % _enemiesModel.SpawnDuration == 0)
            {
                Spawn();
            }
        }
        
        protected override void Spawn()
        {
            Vector3 spawnPosition = GetRandomSpawnPosition();
            EnemyView enemyView = Instantiate(enemyViewPrefab, spawnPosition, Quaternion.identity, transform);
            enemyView.SetTarget(target);
            _enemies.Add(enemyView);
        }

        protected override void Reset()
        {
            
        }

        private void StartSpawn()
        {
            _timer.Start();
        }
    }
}