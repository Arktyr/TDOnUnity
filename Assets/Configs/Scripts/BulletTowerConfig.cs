using Implementations.Bullet.Tower.Scripts;
using UnityEngine;

namespace Configs.Scripts
{
    [CreateAssetMenu(fileName = "BulletTowerConfig", menuName = "Configs/BulletTower")]
    public class BulletTowerConfig : ScriptableObject
    {
        [SerializeField] private BulletTower tower;
        [SerializeField] private BulletControllerConfig bulletControllerConfig;
        [SerializeField] private float bulletRateOfFire;
        [SerializeField] private float bulletTowerDamage;
        [SerializeField] private float priceBulletTower;
        public BulletControllerConfig BulletControllerConfig => bulletControllerConfig;
        public BulletTower Tower => tower;
        public float BulletRateOfFire => bulletRateOfFire;
        public float BulletTowerDamage => bulletTowerDamage;
        public float PriceBulletTower => priceBulletTower;
    }
}
