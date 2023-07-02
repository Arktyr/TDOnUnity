using System.Collections.Generic;
using Implementations.BaseTowerLogic;
using Implementations.Bullet_Tower.Tower.Scripts;
using UnityEngine;

namespace Implementations.PowerUpTowers.RateOfFireUpTower.Scripts
{
    public class RateOfFireUpTower : BaseTower
    {
        private float _percentsUpRateOfFire;

        private float _tempUpRateOfFire;
        
        private readonly List<BulletTower> _bulletTowers = new();

        public void Construct(float RateOfFire, float price)
        {
            _percentsUpRateOfFire = RateOfFire;
            _price = price;
        }
        
        private void OnDestroy()
        {
            foreach (var tower in _bulletTowers)
            {
                if (tower == null) return;
                
                tower.SetRateOfFire(tower.BulletRateOfFire + _tempUpRateOfFire);
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out BulletTower bulletTower))
            {
                _tempUpRateOfFire = bulletTower.BulletRateOfFire * _percentsUpRateOfFire / 100;
                
                _bulletTowers.Add(bulletTower);
                bulletTower.SetRateOfFire(bulletTower.BulletRateOfFire -
                                          _tempUpRateOfFire);
            }
        }
    }
}