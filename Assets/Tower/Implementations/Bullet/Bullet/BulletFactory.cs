using System.Collections.Generic;
using System.Linq;
using Configs;
using UnityEngine;

namespace Bullet_Tower
{
    public class BulletFactory : MonoBehaviour
    {
        [SerializeField] private float startCountBulletPool;
        private BulletControllerConfig _bulletControllerConfig;
        private int _towerCount;
        private bool _isCreatePool;
        private Queue<BulletController> _bulletPool;
        private Queue<BulletController> _activeBullet;

        public void ConstructConfig(BulletControllerConfig bulletControllerConfig)
        {
            _bulletControllerConfig = bulletControllerConfig;
            if (_isCreatePool == false)
            {
                CreatePool();
            }
        }

        private void ConstructBullet(Vector3 pos, Vector3 target, float bulletDamage, BulletFactory bulletFactory)
        {
            _activeBullet.First().gameObject.SetActive(true);
            _activeBullet.First().transform.position = pos;
            _activeBullet.First().Construct(bulletFactory,bulletDamage, _bulletControllerConfig.BulletSpeed, target);
            _activeBullet.Dequeue().BulletMovement();
        }

        private void CreatePool()
        {
            _isCreatePool = true;
            _activeBullet = new Queue<BulletController>();
            _bulletPool = new Queue<BulletController>();
            for (int i = 0; i < startCountBulletPool; i++)
            {
                BulletController createdObject = Instantiate(_bulletControllerConfig.BulletController);
                _bulletPool.Enqueue(createdObject);
                _bulletPool.Peek().gameObject.SetActive(false);
            }
        }

        public void TakeFromPool(Vector3 pos, Vector3 target, float bulletDamage, BulletFactory bulletFactory)
        {
            if (_bulletPool.Count == 0)
            {
                AddToPool(pos,target,bulletDamage,bulletFactory);
            }
            for (int i = 0; i < _bulletPool.Count; i++)
            {
                if (_bulletPool.ElementAt(i).gameObject.activeSelf == false)
                {
                    _activeBullet.Enqueue(_bulletPool.Dequeue());
                    ConstructBullet(pos, target, bulletDamage, bulletFactory);
                    break;
                }
            }
        }

        public void ReturnToPool(BulletController bulletController)
        {
            _bulletPool.Enqueue(bulletController);
            bulletController.gameObject.SetActive(false);
        }

        private void AddToPool(Vector3 pos, Vector3 target, float bulletDamage, BulletFactory bulletFactory)
        {
            var createdObject = Instantiate(_bulletControllerConfig.BulletController);
            _bulletPool.Enqueue(createdObject);
            TakeFromPool(pos,target,bulletDamage,bulletFactory);
        }
    }
}