using UnityEngine;

namespace SpawnService
{
    public abstract class MonoPoolObject : MonoBehaviour
    {
        public virtual void Release()
        {
            gameObject.SetActive(true);
        }
        
        public virtual void Destroy()
        {
            gameObject.SetActive(false);
        }

        public virtual bool IsActiveSelf()
        {
            return gameObject.activeSelf;
        }

        public virtual void SetPosition(Vector3 position)
        {
            transform.position = position;
        }
    }
}