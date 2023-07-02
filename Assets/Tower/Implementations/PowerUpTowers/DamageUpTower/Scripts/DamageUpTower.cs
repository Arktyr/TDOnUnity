using System.Collections.Generic;
using Implementations.BaseTowerLogic;
using UnityEngine;

namespace Implementations.PowerUpTowers.DamageUpTower.Scripts
{
    public class DamageUpTower : BaseTower
    {
        private float _percentsUpDamage;

        private float _tempUpDamage;
        
        private readonly List<BaseAttackTower> _baseAttackTowers = new();

        public void Construct(float damage, float price)
        {
            _percentsUpDamage = damage;
            _price = price;
        }

        private void OnDestroy()
        {
            foreach (var tower in _baseAttackTowers)
            {
                tower.SetDamage(tower.TowerDamage - _tempUpDamage);
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out BaseAttackTower baseAttackTower))
            {
                _tempUpDamage = baseAttackTower._towerDamage * _percentsUpDamage / 100;
                    
                _baseAttackTowers.Add(baseAttackTower);
                baseAttackTower.SetDamage(baseAttackTower.TowerDamage + 
                                          _tempUpDamage);
            }
        }
    }
}