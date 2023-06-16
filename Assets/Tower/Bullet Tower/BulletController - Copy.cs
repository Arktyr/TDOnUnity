using System.Collections;
using Enemy;
using UnityEngine;

namespace Bullet_Tower
{
    public class BulletController : MonoBehaviour
    {
        public float bulletTowerDamage;

        protected void Start()
        {
            StartCoroutine(CycleLifeTimeBullet());
        }

        protected void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out EnemyController enemyController))
            {
                enemyController.TakeDamage(bulletTowerDamage);
                Destroy(gameObject);
            }
        }

        private IEnumerator CycleLifeTimeBullet()
        {
            yield return new WaitForSeconds(5);
            Destroy(gameObject);
        }
    }
}
