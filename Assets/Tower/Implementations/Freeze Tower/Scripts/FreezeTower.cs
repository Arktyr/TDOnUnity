using System.Linq;
using Implementations.BaseTowerLogic;
using UnityEngine;

namespace Implementations.Freeze_Tower.Scripts
{
    [RequireComponent(typeof(LineRenderer))]
    public class FreezeTower : BaseAttackLasersTower
    {
        private float _freezingPercents;
        private float _freezePower;
        private float _freezeDuration;
        
        public void Construct(float freezeTowerDamage, float freezingPercents, float freezeDuration, float price)
        {
            _towerDamage = freezeTowerDamage;
            _freezingPercents = freezingPercents;
            _freezeDuration = freezeDuration;
            _price = price;
        }
        
        private void Start()
        {
            _freezePower = _freezingPercents / 100;
            LaserLine = transform.GetChild(0).GetComponent<LineRenderer>();
        }

        private void FixedUpdate()
        {
            if (CheckingEnemyCount()) LaserFire(_towerDamage);
            
            else SetPositionLaser(false);
        }
        
        protected override void LaserFire(float damage)
        {
            base.LaserFire(damage);
            Freeze();
        }

        private void Freeze()
        {
            EnemyInRadius.First().FreezeAilment.FreezeEnemy(EnemyInRadius.First(), _freezePower, _freezeDuration);
        }
    }
}
