﻿using System.Collections.Generic;
using System.Linq;
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
            _gameplayModel.OnGameFinished += GameFinished;
        }

        private void OnDestroy()
        {
            _timer.OnTimerTick -= OnTimerTick;
            _gameplayModel.OnGameStarted -= StartSpawn;
            _gameplayModel.OnGameFinished -= GameFinished;
        }

        private void Update()
        {
            _timer.Tick();
        }

        private void OnTimerTick(int time)
        {
            if (time > 0 && time % _enemiesModel.SpawnDuration == 0 && _gameplayModel.GameStarted)
            {
                Spawn();
            }
        }
        
        protected override void Spawn()
        {
            Vector3 spawnPosition = GetRandomSpawnPosition();
            EnemyView enemyView = _enemies.FirstOrDefault(x => !x.IsActiveSelf());
            if (enemyView != null)
            {
                enemyView.SetPosition(spawnPosition);
                enemyView.Release();
                enemyView.SetTarget(target);
            }
            else
            {
                enemyView = Instantiate(enemyViewPrefab, spawnPosition, Quaternion.identity, transform);
                enemyView.SetTarget(target);
                _enemies.Add(enemyView);
            }
        }

        protected override void ResetPool()
        {
            foreach (var enemy in _enemies)
            {
                enemy.Destroy();
            }
        }

        private void StopEnemies()
        {
            foreach (var enemy in _enemies)
            {
                enemy.StopEnemy();
            }
        }

        private void StartSpawn()
        {
            ResetPool();
            _timer.Start();
        }

        private void GameFinished()
        {
            StopEnemies();
            _timer.Stop();
            _timer.Reset();
        }
    }
}