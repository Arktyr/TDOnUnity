using System;
using System.Collections;
using Enemies.Scripts;
using Unity.VisualScripting;
using UnityEngine;

namespace Implementations.Bullet_Tower.Bullet.Scripts
{
    [RequireComponent(typeof(BulletController))]
    public class BulletController : MonoBehaviour
    {
        private BulletController _bulletController;
        private BulletFactory _bulletFactory;
        private Rigidbody _bulletRigidBody;
        
        private float _bulletDamage;
        private float _bulletSpeed;
        
        private Vector3 _target;

        public event Action<BulletController> OnDestroy; 

        public void Construct(float bulletDamage, float bulletSpeed, Vector3 target)
        {
            _bulletDamage = bulletDamage;
            _bulletSpeed = bulletSpeed;
            _target = target;
        }

        private void OnEnable() => StartCoroutine(CycleLifeTimeBullet());

        private void Start() => _bulletRigidBody = GetComponent<Rigidbody>();

        private void Update() => BulletMovement();

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Enemy enemyController))
            {
                enemyController.TakeDamage(_bulletDamage);
                
                OnDestroy?.Invoke(this);
            }
        }

        private void BulletMovement()
        {
            Vector3 position = _bulletRigidBody.transform.position;

            Vector3 direction = -(position - _target).normalized;
            Vector3 velocity = direction * (_bulletSpeed * Time.fixedDeltaTime);
                
            _bulletRigidBody.velocity = velocity;
        }
        
        private IEnumerator CycleLifeTimeBullet()   
        {
            yield return new WaitForSeconds(1);
            
            OnDestroy?.Invoke(this);
        }
    }
}

