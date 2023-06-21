using System.Collections;
using Windows.API;
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
        private Vector3 _startPosition;
        
        private void Start()
        {
            _agent = GetComponent<NavMeshAgent>();
            CharacterMovementStrategy();
            _gameplayModel = DIContainer.Resolve<GameplayModel>();
            _windowsService = DIContainer.Resolve<IWindowsService>();
            _startPosition = transform.position;

            _gameplayModel.OnGameStarted += GameStarted;
        }

        private void OnDestroy()
        {
            _gameplayModel.OnGameStarted -= GameStarted;
        }

        private void Update()
        {
            if (_gameplayModel.GameStarted)
                _characterInput.CharacterInput();
        }

        private void CharacterMovementStrategy()
        {
#if UNITY_EDITOR
            Debug.Log("MouseCharacterMovement");
            _characterInput = new MouseCharacterMovement(transform, _agent);
#else
            Debug.Log("TouchCharacterMovement");
           _characterInput = new TouchCharacterMovement(transform, _agent);
#endif
        }
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.TryGetComponent<EnemyView>(out var isEnemyTriggered) ||
                other.gameObject.TryGetComponent<MineView>(out var isMineTriggered))
            {
                _gameplayModel.FinishGame();
                if (isEnemyTriggered)
                    _windowsService.ShowWindow(typeof(FinishGamePopup));
                else
                    StartCoroutine(DelayForAnimation());
            }
                
        }

        private IEnumerator DelayForAnimation()
        {
            yield return new WaitForSeconds(1);
            _windowsService.ShowWindow(typeof(FinishGamePopup));
        }

        private void GameStarted()
        {
            transform.position = _startPosition;
        }
    }
}