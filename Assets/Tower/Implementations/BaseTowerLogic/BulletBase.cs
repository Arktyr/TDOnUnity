using System;
using System.Collections;
using Implementations.Bullet_Tower.Bullet.Scripts;
using UnityEngine;

namespace Implementations.BaseTowerLogic
{
    [RequireComponent(typeof(BulletBase))]
    public abstract class BulletBase : MonoBehaviour
    {
        private BulletBase _bulletBase;
        private BulletFactory _bulletFactory;
        private Rigidbody _bulletRigidBody;
        
        public float _bulletDamage;
        private float _bulletSpeed;
        private float _delayBeforeDestroy;
        
        private Vector3 _target;
        
        public event Action<BulletBase> OnDestroy;
        
        public float BulletDamage => _bulletDamage;

        public void Construct(float bulletDamage, float bulletSpeed, float delayBeforeDestroy, Vector3 target)
        {
            _bulletDamage = bulletDamage;
            _bulletSpeed = bulletSpeed;
            _delayBeforeDestroy = delayBeforeDestroy;
            _target = target;
        }

        private void OnEnable()
        {
            _bulletRigidBody = GetComponent<Rigidbody>();
            StartCoroutine(CycleLifeTimeBullet(_delayBeforeDestroy));
        }
        
        protected virtual void OnCollisionEnter(Collision other) => OnDestroy?.Invoke(this);

        public void BulletMovement()
        {
            Vector3 position = _bulletRigidBody.transform.position;

            Vector3 direction = -(position - _target).normalized;
            Vector3 velocity = direction * (_bulletSpeed * Time.fixedDeltaTime);
                
            _bulletRigidBody.velocity = velocity;
        }
        
        private IEnumerator CycleLifeTimeBullet(float delayBeforeDestroy)   
        {
            yield return new WaitForSeconds(delayBeforeDestroy);
            
            OnDestroy?.Invoke(this);
        }
    }
}

