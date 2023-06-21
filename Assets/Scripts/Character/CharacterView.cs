﻿using Windows.API;
using Character.API;
using Character.Impl;
using Enemy;
using Models;
using ServiceLocator;
using UI;
using UnityEngine;
using UnityEngine.AI;

namespace Character
{
    [RequireComponent(typeof(NavMeshAgent ))]
    public class CharacterView : MonoBehaviour
    {
        private NavMeshAgent _agent;
        private ICharacterInput _characterInput;
        private GameplayModel _gameplayModel;
        private IWindowsService _windowsService;
        
        private void Start()
        {
            _agent = GetComponent<NavMeshAgent>();
            CharacterMovementStrategy();
            _gameplayModel = DIContainer.Resolve<GameplayModel>();
            _windowsService = DIContainer.Resolve<IWindowsService>();
        }

        private void Update()
        {
            if (_gameplayModel.GameStarted)
                _characterInput.CharacterInput();
        }

        private void CharacterMovementStrategy()
        {
            _characterInput = new MouseCharacterMovement(transform, _agent);
        }
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.TryGetComponent<EnemyView>(out var isEnemyTriggered) ||
                other.gameObject.TryGetComponent<MineView>(out var isMineTriggered))
            {
                _gameplayModel.FinishGame();
                _windowsService.ShowWindow(typeof(FinishGamePopup));
            }
                
        }
    }
}