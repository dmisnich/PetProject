using System.Collections.Generic;
using Models;
using ServiceLocator;
using SpawnService;
using UnityEngine;

namespace Enemy
{
    public class MinePoolView : ASpawner
    {
        [SerializeField] private MineView mineViewPrefab;

        [Range(0, 10)]
        [SerializeField] private int countOfMines = 5;
        
        private GameplayModel _gameplayModel;
        private List<MineView> _mines = new List<MineView>();
        
        private void Start()
        {
            _gameplayModel = DIContainer.Resolve<GameplayModel>();
            _gameplayModel.OnGameStarted += Spawn;
        }

        private void OnDestroy()
        {
            _gameplayModel.OnGameStarted -= Spawn;
        }
        
        protected override void Spawn()
        {
            ResetPool();
            if (_mines.Count == countOfMines)
            {
                foreach (var mine in _mines)
                {
                    Vector3 spawnPosition = GetRandomSpawnPosition();
                    mine.SetPosition(spawnPosition);
                    mine.Release();
                }
            }
            else
            {
                var value = countOfMines - _mines.Count;
                for (int count = 0; count < value; count++)
                {
                    Vector3 spawnPosition = GetRandomSpawnPosition();
                    MineView enemyView = Instantiate(mineViewPrefab, spawnPosition, Quaternion.identity, transform);
                    _mines.Add(enemyView);
                }
            }
        }

        protected override void ResetPool()
        {
            foreach (var mine in _mines)
            {
                mine.Destroy();
            }
        }
    }
}