using Character.API;
using Character.Impl;
using Models;
using ServiceLocator;
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
        
        private void Start()
        {
            _agent = GetComponent<NavMeshAgent>();
            CharacterMovementStrategy();
            _gameplayModel = DIContainer.Resolve<GameplayModel>();
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
    }
}