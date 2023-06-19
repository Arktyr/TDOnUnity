using System.Collections;
using Enemies.Scripts;
using UnityEngine;

namespace Implementations.Bullet.Bullet.Scripts
{
    public class BulletController : MonoBehaviour
    {
        private float _bulletTowerDamage;
        private BulletFactory _bulletFactory;
        private BulletController _bulletController;
        private float _bulletSpeed;
        private Vector3 _target;
        private Rigidbody _bulletRigidBody;

        public void Construct(BulletFactory bulletFactory, float bulletTowerDamage, float bulletSpeed, Vector3 target)
        {
            _bulletController = GetComponent<BulletController>();
            _bulletFactory = bulletFactory;
            _bulletTowerDamage = bulletTowerDamage;
            _bulletSpeed = bulletSpeed;
            _target = target;
        }
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Enemy enemyController))
            {
                enemyController.TakeDamage(_bulletTowerDamage);
                _bulletFactory.ReturnToPool(_bulletController);
            }
        }

        public void BulletMovement()
        {
            StartCoroutine(CycleLifeTimeBullet());
            _bulletRigidBody = GetComponent<Rigidbody>();
            Vector3 velocity = (transform.position - _target).normalized;
            _bulletRigidBody.velocity = -velocity * (_bulletSpeed * Time.fixedDeltaTime);
        }
        
        private IEnumerator CycleLifeTimeBullet()   
        {
            yield return new WaitForSeconds(1);
            _bulletFactory.ReturnToPool(_bulletController);
        }
    }
}
