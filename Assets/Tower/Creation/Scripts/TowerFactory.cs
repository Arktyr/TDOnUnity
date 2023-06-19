using System;
using Configs;
using Configs.Scripts;
using Implementations.Bullet.Bullet.Scripts;
using Implementations.Bullet.Tower.Scripts;
using Implementations.Freeze.Scripts;
using Implementations.Laser.Scripts;
using UnityEngine;

namespace Creation.Scripts
{
    public class TowerFactory : MonoBehaviour
    {
        [SerializeField] private BulletTowerConfig bulletTowerConfig;
        [SerializeField] private FreezeTowerConfig freezeTowerConfig;
        [SerializeField] private LaserTowerConfig laserTowerConfig;

        public void Create(TowersTypes.TowerTypes type, Vector3 position, BulletFactory bulletFactory)
        {
            switch (type)
            {
                case TowersTypes.TowerTypes.BulletTower:
                {
                    CreateBulletTower(position, bulletFactory);
                }
                    break;
                case TowersTypes.TowerTypes.FreezeTower:
                {
                    CreateFreezeTower(position);
                }
                    break;
                case TowersTypes.TowerTypes.LaserTower:
                {
                    CreateLaserTower(position);
                }
                    break;
                default:
                {
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
                }
            }
        }

        private void CreateFreezeTower(Vector3 pos)
        {
            FreezeTower tower  = Instantiate(freezeTowerConfig.Tower, pos, Quaternion.identity);
            tower.Construct(freezeTowerConfig.FreezeTowerDamage,freezeTowerConfig.FreezingPower);
        }

        private void CreateLaserTower(Vector3 pos)
        {
            LaserTower tower = Instantiate(laserTowerConfig.Tower, pos, Quaternion.identity);
            tower.Construct(laserTowerConfig.LaserTowerDamage);
        }

        private void CreateBulletTower(Vector3 pos,BulletFactory bulletFactory)
        {
            BulletTower tower = Instantiate(bulletTowerConfig.Tower, pos, Quaternion.identity);
            tower.Construct(bulletFactory, bulletTowerConfig.BulletRateOfFire, bulletTowerConfig.BulletTowerDamage, bulletTowerConfig.BulletControllerConfig);
        }

        public float GetPriceTower(TowersTypes.TowerTypes type)
        {
            switch (type)
            {
                case TowersTypes.TowerTypes.BulletTower:
                    return bulletTowerConfig.PriceBulletTower;
                case TowersTypes.TowerTypes.FreezeTower:
                    return freezeTowerConfig.PriceFreezeTower;
                case TowersTypes.TowerTypes.LaserTower:
                    return laserTowerConfig.PriceLaserTower;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }
    }
}
