using System;
using Configs;
using Implementations.Bullet.Bullet;
using Implementations.Bullet.Tower;
using Implementations.Freeze;
using Implementations.Laser;
using UnityEngine;

namespace Creation
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

        private void CreateFreezeTower(Vector3 position)
        {
            FreezeTower tower  = Instantiate(freezeTowerConfig.Tower, position, Quaternion.identity);
            tower.Construct(freezeTowerConfig.FreezeTowerDamage,freezeTowerConfig.FreezingPower);
        }

        private void CreateLaserTower(Vector3 position)
        {
            LaserTower tower = Instantiate(laserTowerConfig.Tower, position, Quaternion.identity);
            tower.Construct(laserTowerConfig.LaserTowerDamage);
        }

        private void CreateBulletTower(Vector3 position, BulletFactory bulletFactory)
        {
            BulletTower tower = Instantiate(bulletTowerConfig.Tower, position, Quaternion.identity);
            tower.Construct(bulletFactory, bulletTowerConfig.BulletRateOfFire, bulletTowerConfig.BulletTowerDamage, bulletTowerConfig.BulletControllerConfig);
        }

        
    }
}
