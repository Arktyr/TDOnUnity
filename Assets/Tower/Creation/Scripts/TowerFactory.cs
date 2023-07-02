using System;
using Configs.Scripts;
using Implementations.AOE_Tower.Scripts;
using Implementations.Bullet_Tower.Bullet.Scripts;
using Implementations.Bullet_Tower.Tower.Scripts;
using Implementations.Freeze_Tower.Scripts;
using Implementations.Laser_Tower.Scripts;
using Implementations.PowerUpTowers.DamageUpTower.Scripts;
using Implementations.PowerUpTowers.RateOfFireUpTower.Scripts;
using UnityEngine;

namespace Creation.Scripts
{
    public class TowerFactory : MonoBehaviour
    {
        [SerializeField] private BulletTowerConfig _bulletTowerConfig;
        [SerializeField] private FreezeTowerConfig _freezeTowerConfig;
        [SerializeField] private LaserTowerConfig _laserTowerConfig;
        [SerializeField] private AOETowerConfig _aoeTowerConfig;
        [SerializeField] private DamageUpTowerConfig _damageUpTowerConfig;
        [SerializeField] private RateOfFireUpTowerConfig _rateOfFireUpTowerConfig;
        [SerializeField] private BulletFactory _bulletFactory;
        
        public BulletTowerConfig BulletTowerConfig => _bulletTowerConfig;
        
        public FreezeTowerConfig FreezeTowerConfig => _freezeTowerConfig;
        
        public LaserTowerConfig LaserTowerConfig => _laserTowerConfig;

        public AOETowerConfig AoeTowerConfig => _aoeTowerConfig;

        public DamageUpTowerConfig DamageUpTowerConfig => _damageUpTowerConfig;

        public RateOfFireUpTowerConfig RateOfFireUpTowerConfig => _rateOfFireUpTowerConfig;
        
        public void Create(TowersTypes.TowerTypes type, Vector3 position, PlatformConstructor platformConstructor)
        {
            switch (type)
            {
                case TowersTypes.TowerTypes.BulletTower: CreateBulletTower(position, platformConstructor);
                    break;
                case TowersTypes.TowerTypes.FreezeTower: CreateFreezeTower(position, platformConstructor);
                    break;
                case TowersTypes.TowerTypes.LaserTower: CreateLaserTower(position, platformConstructor);
                    break;
                case TowersTypes.TowerTypes.AOETower: CreateAOETower(position, platformConstructor);
                    break;
                case TowersTypes.TowerTypes.DamageUpTower: CreateDamageUpTower(position, platformConstructor);
                    break;
                case TowersTypes.TowerTypes.RateOfFireUpTower: CreateRateOfFireUpTower(position, platformConstructor);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }
        
        private void CreateLaserTower(Vector3 position, PlatformConstructor platformConstructor)
        {
            LaserTower tower = Instantiate(_laserTowerConfig.Tower, position, Quaternion.identity);
            platformConstructor.SetBaseTower(tower);
            tower.Construct(_laserTowerConfig.LaserTowerDamage, _laserTowerConfig.PriceLaserTower);
        }

        private void CreateBulletTower(Vector3 position, PlatformConstructor platformConstructor)
        {
            BulletTower tower = Instantiate(_bulletTowerConfig.Tower, position, Quaternion.identity);
            platformConstructor.SetBaseTower(tower);
            tower.Construct(_bulletFactory,
                _bulletTowerConfig.BulletControllerConfig, _bulletTowerConfig.TowerDamage, 
                _bulletTowerConfig.BulletRateOfFire, _bulletTowerConfig.PriceBulletTower);
        }
        
        private void CreateFreezeTower(Vector3 position, PlatformConstructor platformConstructor)
        {
            FreezeTower tower  = Instantiate(_freezeTowerConfig.Tower, position, Quaternion.identity);
            platformConstructor.SetBaseTower(tower);
            tower.Construct(_freezeTowerConfig.FreezeTowerDamage,
                _freezeTowerConfig.FreezingPercents,
                _freezeTowerConfig.FreezeDuration, _freezeTowerConfig.PriceFreezeTower);
        }
        
        private void CreateAOETower(Vector3 position, PlatformConstructor platformConstructor)
        {
            AOETower tower  = Instantiate(_aoeTowerConfig.AOETower, position, Quaternion.identity);
            platformConstructor.SetBaseTower(tower);
            tower.Construct(_bulletFactory, _aoeTowerConfig.BulletControllerConfig, _aoeTowerConfig.TowerDamage,
                _aoeTowerConfig.BulletRateOfFire, _aoeTowerConfig.PriceAOETower);
        }
        
        private void CreateDamageUpTower(Vector3 position, PlatformConstructor platformConstructor)
        {
            DamageUpTower tower  = Instantiate(_damageUpTowerConfig.DamageUpTower, position, Quaternion.identity);
            platformConstructor.SetBaseTower(tower);
            tower.Construct(_damageUpTowerConfig.PercentsUpDamage, _damageUpTowerConfig.Price);
        }

        private void CreateRateOfFireUpTower(Vector3 position, PlatformConstructor platformConstructor)
        {
            RateOfFireUpTower tower  = Instantiate(_rateOfFireUpTowerConfig.PercentsRateOfFireUpTower, position, Quaternion.identity);
            platformConstructor.SetBaseTower(tower);
            tower.Construct(_rateOfFireUpTowerConfig.UpRateOfFire, _rateOfFireUpTowerConfig.Price);
        }
    }
}
