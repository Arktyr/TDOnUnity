using System.Linq;
using Enemies.Scripts;
using UnityEngine;

namespace Implementations.Freeze.Scripts
{
    [RequireComponent(typeof(LineRenderer))]
    public class FreezeTower : BaseTower.BaseTower
    {
        private Enemy _currentEnemy;
        private float _freezeTowerDamage;
        private float _freezingPower;
        public float freezePower;
        private bool _isAttack;
        private float _freezeStacks;

        public void Construct(float freezeTowerDamage, float freezingPower)
        {
            _freezeTowerDamage = freezeTowerDamage;
            _freezingPower = freezingPower;
        }
        
        protected override void Start()
        {
            base.Start();
            freezePower = _freezingPower / 100;
            LaserLine = transform.GetChild(0).GetComponent<LineRenderer>();
        }

        private void FixedUpdate()
        {
            if (CheckingEnemyCount())
            {
                LaserFire(_freezeTowerDamage);
            }
            else
            {
                SetPositionLaser(false);
            }
        }

        protected override void OnTriggerEnter(Collider other)
        {
            base.OnTriggerEnter(other);
            if (other.TryGetComponent(out Enemy enemyController))
            {
                enemyController.EnemyAilments.Freeze.AddInRadius();
            }
        }
        
        protected override void OnTriggerExit(Collider other)
        {
            
            if (other.TryGetComponent(out Enemy enemyController))
            {
                if (_currentEnemy == enemyController)
                {
                    _currentEnemy = null;
                }
                enemyController.EnemyAilments.Freeze.RemoveInRadius();
                if (enemyController.EnemyAilments.Freeze.InRadius == 0)
                {
                    UnFreeze(enemyController);
                }
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
            if (CheckingEnemy())
            {
                if (_currentEnemy == null || _currentEnemy != EnemyInRadius.ElementAt(IntCheckingEnemyInRadius()).GetComponent<Enemy>())
                {
                    _isAttack = false;
                    _currentEnemy = EnemyInRadius.ElementAt(IntCheckingEnemyInRadius()).GetComponent<Enemy>();
                    _currentEnemy.EnemyAilments.Freeze.AddFreezeStack();
                }
                if (_currentEnemy.EnemyAilments.Freeze.FreezeStacks > 0)
                {
                    if (_isAttack == false)
                    {
                        _isAttack = true;
                        Debug.Log(_currentEnemy.EnemyAilments.Freeze.FreezeStacks);
                        FreezeEnemy(_currentEnemy);
                    }
                }
            }
        }

        private void FreezeEnemy(Enemy currentEnemy)
        {
            float currentFreezeStacks = currentEnemy.EnemyAilments.Freeze.FreezeStacks;
            
            switch (currentFreezeStacks)
            {
                case 0:
                {
                    currentEnemy.SetSpeed(currentEnemy.StartSpeed); 
                    break;
                }
                
                case > 0:
                {
                    Debug.Log(SetSlowdown(currentEnemy));
                    currentEnemy.SetSpeed(SetSlowdown(currentEnemy));
                    currentEnemy.CheckMinimumSpeed();
                    break;
                }
            }
        }
        
        private void UnFreeze(Enemy enemy)
        {
            enemy.EnemyAilments.Freeze.SetZeroFreezeStack();
            enemy.SetSpeed(enemy.StartSpeed);
        }

        private float SetSlowdown(Enemy currentEnemy)
        {
            return currentEnemy.StartSpeed -
                   currentEnemy.StartSpeed * (freezePower * currentEnemy.EnemyAilments.Freeze.FreezeStacks);
        }
    }
}