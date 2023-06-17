using UnityEngine;
using Bullet_Tower;

namespace Configs
{
    [CreateAssetMenu(fileName = "BulletTowerConfig", menuName = "Configs/BulletTower")]
    public class BulletTowerConfig : ScriptableObject
    {
        [SerializeField] private BulletTower tower;
        [SerializeField] private BulletFactory bulletFactory;
        [SerializeField] private float bulletRateOfFire;
        [SerializeField] private float bulletSpeed;
        [SerializeField] private float bulletTowerDamage;
        [SerializeField] private float priceBulletTower;
        public BulletTower Tower => tower;
        public BulletFactory BulletFactory => bulletFactory;
        public float BulletRateOfFire => bulletRateOfFire;
        public float BulletSpeed => bulletSpeed;
        public float BulletTowerDamage => bulletTowerDamage;
        public float PriceBulletTower => priceBulletTower;
    }
}
