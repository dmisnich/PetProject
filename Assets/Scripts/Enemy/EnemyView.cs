using System;
using Models;
using ServiceLocator;
using UnityEngine;
using UnityEngine.AI;

namespace Enemy
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class EnemyView : MonoBehaviour
    {
        private EnemiesModel _enemiesModel;
        private NavMeshAgent _navMeshAgent;
        private GameplayModel _gameplayModel;
        private Transform _target;

        private void Start()
        {
            _enemiesModel = DIContainer.Resolve<EnemiesModel>();
            _gameplayModel = DIContainer.Resolve<GameplayModel>();
            _navMeshAgent = GetComponent<NavMeshAgent>();
            _enemiesModel.EnemiesSpeedChanged += EnemySpeedChanged;
            
            EnemySpeedChanged();
        }

        private void OnDestroy()
        {
            _enemiesModel.EnemiesSpeedChanged -= EnemySpeedChanged;
        }

        private void Update()
        {
            if (_gameplayModel.GameStarted)
                _navMeshAgent.SetDestination(_target.position);
        }

        public void SetTarget(Transform target)
        {
            _target = target;
        }

        private void EnemySpeedChanged()
        {
            _navMeshAgent.speed = _enemiesModel.EnemiesSpeed;
        }
    }
}