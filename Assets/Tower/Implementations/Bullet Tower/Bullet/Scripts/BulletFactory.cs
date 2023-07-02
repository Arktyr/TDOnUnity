using Configs.Scripts;
using Implementations.BaseTowerLogic;
using UnityEngine;

namespace Implementations.Bullet_Tower.Bullet.Scripts
{
    public class BulletFactory : MonoBehaviour
    {
        [SerializeField] private BulletPool _bulletPool;

        public BulletBase CreateBullet(BulletControllerConfig bulletControllerConfig, float damage, Vector3 position,
            Vector3 target)
        {
            if (_bulletPool.IsCreate == false) _bulletPool.CreatePool(bulletControllerConfig.BulletBase);

            BulletBase bulletBase = 
                _bulletPool.TakeFromPool(bulletControllerConfig.BulletBase, position);
            
            bulletBase.Construct(damage, bulletControllerConfig.BulletSpeed,
                bulletControllerConfig.DelayBeforeDestroy, target);

            return bulletBase;
        }
    }
}