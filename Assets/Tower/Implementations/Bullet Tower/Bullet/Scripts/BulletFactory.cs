using Configs.Scripts;
using UnityEngine;

namespace Implementations.Bullet_Tower.Bullet.Scripts
{
    public class BulletFactory : MonoBehaviour
    {
        [SerializeField] private BulletPool _bulletPool;

        public BulletController CreateBullet(BulletControllerConfig bulletControllerConfig, Vector3 position, Vector3 target)
        {
            if (_bulletPool.IsCreate == false) _bulletPool.CreatePool(bulletControllerConfig.BulletController);

            BulletController bulletController = 
                _bulletPool.TakeFromPool(bulletControllerConfig.BulletController, position);
            
            bulletController.Construct(bulletControllerConfig.BulletDamage, bulletControllerConfig.BulletSpeed, bulletControllerConfig.DelayBeforeDestroy, target);

            return bulletController;
        }
    }
}