using UnityEngine;
using Bullet_Tower;

namespace Configs
{
    [CreateAssetMenu(fileName = "BulletTowerConfig", menuName = "Configs/BulletTower")]
    public class BulletTowerConfig : ScriptableObject
    {
        [SerializeField] private BulletTower tower;
        [SerializeField] private BulletController bullet;
        [SerializeField] private float bulletRateOfFire;
        [SerializeField] private float bulletSpeed;
        [SerializeField] private float bulletTowerDamage;
        public BulletTower Tower => tower;
        public BulletController Bullet => bullet;
        public float BulletRateOfFire => bulletRateOfFire;
        public float BulletSpeed => bulletSpeed;
        public float BulletTowerDamage => bulletTowerDamage;
    }
}
