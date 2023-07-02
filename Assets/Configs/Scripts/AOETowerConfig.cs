using Implementations.AOE_Tower.Scripts;
using UnityEngine;

namespace Configs.Scripts
{
    [CreateAssetMenu(fileName = "AOETowerConfig", menuName = "Configs/AOETowerConfig")]
    public class AOETowerConfig : ScriptableObject
    {
        [SerializeField] private AOETower _aoeTower;
        [SerializeField] private BulletControllerConfig _bulletControllerConfig;
        [SerializeField] private float _towerDamage;
        [SerializeField] private float _bulletRateOfFire;
        [SerializeField] private float _priceAOETower;
        
        public AOETower AOETower => _aoeTower;
        
        public BulletControllerConfig BulletControllerConfig => _bulletControllerConfig;

        public float TowerDamage => _towerDamage;
        
        public float BulletRateOfFire => _bulletRateOfFire;
        
        public float PriceAOETower => _priceAOETower;

    }
}