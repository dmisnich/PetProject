using UnityEngine;

namespace SpawnService
{
    public abstract class ASpawner : MonoBehaviour
    {
        [SerializeField] protected Vector3 minSpawnPosition;
        [SerializeField] protected Vector3 maxSpawnPosition;

        protected abstract void Spawn();
        protected abstract void ResetPool();
        
        protected Vector3 GetRandomSpawnPosition()
        {
            float randomX = Random.Range(minSpawnPosition.x, maxSpawnPosition.x);
            float randomY = Random.Range(minSpawnPosition.y, maxSpawnPosition.y);
            float randomZ = Random.Range(minSpawnPosition.z, maxSpawnPosition.z);

            return new Vector3(randomX, randomY, randomZ);
        }
    }
}