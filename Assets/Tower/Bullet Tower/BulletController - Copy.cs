using System;
using System.Collections;
using System.Reflection.Emit;
using Enemy;
using UnityEngine;

namespace Bullet_Tower
{
    public class BulletController : MonoBehaviour
    {
        private float _bulletTowerDamage;
        private float _bulletSpeed;
        private Vector3 _target;
        private Rigidbody _bulletRigidBody;

        public void Construct(float bulletTowerDamage, float bulletSpeed, Vector3 target)
        {
            _bulletTowerDamage = bulletTowerDamage;
            _bulletSpeed = bulletSpeed;
            _target = target;
        }
        
        private void Start()
        {
            StartCoroutine(CycleLifeTimeBullet());
            BulletMovement();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out EnemyController enemyController))
            {
                enemyController.TakeDamage(_bulletTowerDamage);
                Destroy(gameObject);
            }
        }

        private IEnumerator CycleLifeTimeBullet()   
        {
            yield return new WaitForSeconds(5);
            Destroy(gameObject);
        }
        
        private void BulletMovement()
        {
            _bulletRigidBody = GetComponent<Rigidbody>();
            Vector3 velocity = (transform.position - _target).normalized;
            _bulletRigidBody.velocity = -velocity * (_bulletSpeed * Time.fixedDeltaTime);
        }
    }
}

