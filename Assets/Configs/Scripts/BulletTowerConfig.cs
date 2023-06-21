using Implementations.Bullet_Tower.Tower.Scripts;
using UnityEngine;


namespace Configs.Scripts
{
    [CreateAssetMenu(fileName = "BulletTowerConfig", menuName = "Configs/BulletTower")]
    public class BulletTowerConfig : ScriptableObject
    {
        [SerializeField] private BulletTower _tower;
        [SerializeField] private BulletControllerConfig _bulletControllerConfig;
        [SerializeField] private float _bulletRateOfFire;
        [SerializeField] private float _priceBulletTower;
        
        public BulletTower Tower => _tower;
        
        public BulletControllerConfig BulletControllerConfig => _bulletControllerConfig;
        
        public float BulletRateOfFire => _bulletRateOfFire;
        
        public float PriceBulletTower => _priceBulletTower;
    }
}
