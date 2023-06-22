using System.Linq;
using Enemies.Scripts;
using UnityEngine;

namespace Implementations.Freeze_Tower.Scripts
{
    [RequireComponent(typeof(LineRenderer))]
    public class FreezeTower : BaseTower.BaseTower
    {
        private Enemy _currentEnemy;
        
        private float _freezeTowerDamage;
        private float _freezingPercents;
        private float _freezePower;
        private float _freezeStacks;
        
        private bool _isAttack;

        public void Construct(float freezeTowerDamage, float freezingPercents)
        {
            _freezeTowerDamage = freezeTowerDamage;
            _freezingPercents = freezingPercents;
        }
        
        private void Start()
        {
            _freezePower = _freezingPercents / 100;
            LaserLine = transform.GetChild(0).GetComponent<LineRenderer>();
        }

        private void FixedUpdate()
        {
            if (CheckingEnemyCount()) LaserFire(_freezeTowerDamage);
            
            else SetPositionLaser(false);
        }

        protected override void OnTriggerEnter(Collider other)
        {
            base.OnTriggerEnter(other);
            if (other.TryGetComponent(out Enemy enemy))
            {
                enemy.FreezeAilment.AddInRadius();
            }
        }
        
        protected override void OnTriggerExit(Collider other)
        {
            if (other.TryGetComponent(out Enemy enemy))
            {
                if (_currentEnemy == enemy) _currentEnemy = null;
                
                enemy.FreezeAilment.RemoveInRadius();
                
                if (enemy.FreezeAilment.InRadius == 0) UnFreeze(enemy);
            }
            base.OnTriggerExit(other);
        }
        
        protected override void LaserFire(float damage)
        {
            base.LaserFire(damage);
            
            Freeze();
        }

        private void Freeze()
        {
            if (_currentEnemy == null || _currentEnemy != EnemyInRadius.First())
            {
                _isAttack = false;
                _currentEnemy = EnemyInRadius.First();
                _currentEnemy.FreezeAilment.AddFreezeStack();
            }
            
            if (_currentEnemy.FreezeAilment.FreezeStacks > 0)
            { 
                
                if (_isAttack == false)
                {
                    _isAttack = true;
                    FreezeEnemy(_currentEnemy);
                }
            }
        }

        private void FreezeEnemy(Enemy currentEnemy)
        {
            float currentFreezeStacks = currentEnemy.FreezeAilment.FreezeStacks;
            
            switch (currentFreezeStacks)
            {
                case 0:
                {
                    currentEnemy.SetSpeed(currentEnemy.StartSpeed); 
                    break;
                }
                
                case > 0:
                {
                    currentEnemy.SetSpeed(SetSlowdown(currentEnemy));
                    currentEnemy.CheckMinimumSpeed();
                    break;
                }
            }
        }
        
        private void UnFreeze(Enemy enemy)
        {
            enemy.FreezeAilment.SetZeroFreezeStack();
            enemy.SetSpeed(enemy.StartSpeed);
        }

        private float SetSlowdown(Enemy currentEnemy)
        {
            return currentEnemy.StartSpeed - currentEnemy.StartSpeed * 
                (_freezePower * currentEnemy.FreezeAilment.FreezeStacks);
        }
    }
}
