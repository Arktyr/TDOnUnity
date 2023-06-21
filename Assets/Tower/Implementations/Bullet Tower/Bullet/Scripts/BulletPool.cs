using System.Collections.Generic;
using UnityEngine;

namespace Implementations.Bullet_Tower.Bullet.Scripts
{
    public class BulletPool : MonoBehaviour
    {
        [SerializeField] private float startCountBulletPool;
        
        private bool _isCreatePool;
        
        private readonly Queue<BulletController> _bulletPool = new();
        private readonly Queue<BulletController> _activeBullet = new();

        public bool IsCreatePool => _isCreatePool;
        
        public void CreatePool(BulletController bulletController)
        {
            _isCreatePool = true;
            
            for (int i = 0; i < startCountBulletPool; i++)
            {
                _bulletPool.Enqueue(Instantiate(bulletController, transform.parent));
                _bulletPool.Peek().gameObject.SetActive(false);
            }
        }
        public BulletController TakeFromPool(BulletController bulletController, Vector3 position)
        {
            if (_bulletPool.Count == 0) AddToPool(bulletController);
            
            _activeBullet.Enqueue(_bulletPool.Dequeue());

            _activeBullet.Peek().OnDestroy += ReturnToPool;
            _activeBullet.Peek().gameObject.SetActive(true);
            _activeBullet.Peek().transform.position = position;
            
            return _activeBullet.Dequeue();
        }

        private void ReturnToPool(BulletController bulletController)
        {
            bulletController.OnDestroy -= ReturnToPool;
            
            _bulletPool.Enqueue(bulletController);
            bulletController.gameObject.SetActive(false);
        }

        private void AddToPool(BulletController bulletController) => _bulletPool.Enqueue(Instantiate(bulletController, transform.parent));
    }
}