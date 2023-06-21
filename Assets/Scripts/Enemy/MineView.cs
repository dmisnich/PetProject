using System.Collections;
using SpawnService;
using UnityEngine;

namespace Enemy
{
    public class MineView : MonoPoolObject
    {
        [SerializeField] private GameObject mineView;
        [SerializeField] private GameObject explosionVFX;
        [SerializeField] private SphereCollider collider;
        
        private void OnTriggerEnter(Collider other)
        {
            StartCoroutine(ActivateExplosionVFX());
            Destroy();
        }

        private IEnumerator ActivateExplosionVFX()
        {
            explosionVFX.SetActive(true);
            yield return new WaitForSeconds(1);
            explosionVFX.SetActive(false);
        }

        public override void Release()
        {
            mineView.SetActive(true);
            collider.enabled = true;
        }

        public override void Destroy()
        {
            mineView.SetActive(false);
            collider.enabled = false;
        }

        public override bool IsActiveSelf()
        {
            return mineView.activeSelf;
        }
    }
}