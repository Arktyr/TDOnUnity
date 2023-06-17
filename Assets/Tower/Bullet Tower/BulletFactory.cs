using Configs;
using UnityEngine;

namespace Bullet_Tower
{
    public class BulletFactory : MonoBehaviour
    {
        [SerializeField] private BulletControllerConfig bulletControllerConfig;

        public void CreateBullet(Vector3 pos, Vector3 target, float bulletDamage)
        {
            BulletController bullet = Instantiate(bulletControllerConfig.BulletController, pos, Quaternion.identity);
            bullet.Construct(bulletDamage, bulletControllerConfig.BulletSpeed, target);
        }
    }
}