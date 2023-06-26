using System;
using Configs.Scripts;
using Implementations.Bullet_Tower.Bullet.Scripts;
using Implementations.Bullet_Tower.Tower.Scripts;
using Implementations.Freeze_Tower.Scripts;
using Implementations.Laser_Tower.Scripts;
using UnityEngine;

namespace Creation.Scripts
{
    public class TowerFactory : MonoBehaviour
    {
        [SerializeField] private BulletTowerConfig _bulletTowerConfig;
        [SerializeField] private FreezeTowerConfig _freezeTowerConfig;
        [SerializeField] private LaserTowerConfig _laserTowerConfig;
        [SerializeField] private BulletFactory _bulletFactory;
        
        public BulletTowerConfig BulletTowerConfig => _bulletTowerConfig;
        
        public FreezeTowerConfig FreezeTowerConfig => _freezeTowerConfig;
        
        public LaserTowerConfig LaserTowerConfig => _laserTowerConfig;
        
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
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }

        private void CreateFreezeTower(Vector3 position, PlatformConstructor platformConstructor)
        {
            FreezeTower tower  = Instantiate(_freezeTowerConfig.Tower, position, Quaternion.identity);
            platformConstructor.SetBaseTower(tower);
            tower.Construct(_freezeTowerConfig.FreezeTowerDamage,
                _freezeTowerConfig.FreezingPercents,
                _freezeTowerConfig.FreezeDuration);
        }

        private void CreateLaserTower(Vector3 position, PlatformConstructor platformConstructor)
        {
            LaserTower tower = Instantiate(_laserTowerConfig.Tower, position, Quaternion.identity);
            platformConstructor.SetBaseTower(tower);
            tower.Construct(_laserTowerConfig.LaserTowerDamage);
        }

        private void CreateBulletTower(Vector3 position, PlatformConstructor platformConstructor)
        {
            BulletTower tower = Instantiate(_bulletTowerConfig.Tower, position, Quaternion.identity);
            platformConstructor.SetBaseTower(tower);
            tower.Construct(_bulletFactory,
                _bulletTowerConfig.BulletControllerConfig,
                _bulletTowerConfig.BulletRateOfFire);
        }
    }
}
