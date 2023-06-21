using System;
using System.Collections;
using Windows.API;
using Enums;
using Models;
using ServiceLocator;
using UI;
using UnityEngine;

namespace Test
{
    public class GameOver : MonoBehaviour
    {
        private GameplayModel _gameplayModel;
        private IWindowsService _windowsService;
        
        private void Start()
        {
            _gameplayModel = DIContainer.Resolve<GameplayModel>();
            _windowsService = DIContainer.Resolve<IWindowsService>();

            _gameplayModel.OnGameStarted += Finish;
        }

        private void OnDestroy()
        {
            _gameplayModel.OnGameStarted -= Finish;
        }

        private void Finish()
        {
            StartCoroutine(FinishGame());
        }

        private IEnumerator FinishGame()
        {
            yield return new WaitForSeconds(3);
            _gameplayModel.FinishGame();
            _windowsService.ShowWindow(typeof(StartGamePopup));
        }
    }
}