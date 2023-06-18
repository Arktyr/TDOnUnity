using System.Linq;
using UnityEngine;

namespace Implementations.Freeze
{
    [RequireComponent(typeof(LineRenderer))]
    public class FreezeTower : BaseTower
    {
        private float _freezeTowerDamage;
        private float _freezingPower;
        public float freezePower;
        private bool _isAttack;
        private float _freezeStacks;
        private Enemy.Enemy _currentEnemy;

        public void Construct(float freezeTowerDamage, float freezingPower)
        {
            _freezeTowerDamage = freezeTowerDamage;
            _freezingPower = freezingPower;
        }
        
        protected override void Start()
        {
            base.Start();
            freezePower = _freezingPower / 100;
            LaserLine = transform.GetComponentInChildren<LineRenderer>();
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
            if (other.TryGetComponent(out Enemy.Enemy enemyController))
            {
                enemyController.inRadius++;
            }
        }
        
        protected override void OnTriggerExit(Collider other)
        {
            if (other.TryGetComponent(out Enemy.Enemy enemyController))
            {
                if (_currentEnemy == enemyController)
                {
                    _currentEnemy = null;
                }
                enemyController.inRadius--;
                if (enemyController.inRadius == 0)
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
                if (_currentEnemy == null || _currentEnemy != EnemyInRadius.ElementAt(GetFirstEnemyIndex()).GetComponent<Enemy.Enemy>())
                {
                    _isAttack = false;
                    _currentEnemy = EnemyInRadius.ElementAt(GetFirstEnemyIndex()).GetComponent<Enemy.Enemy>();
                }
                if (_currentEnemy.inRadius > 0)
                {
                    if (_isAttack == false)
                    {
                        _isAttack = true;
                        FreezeStacks();
                        GetFreeze(_currentEnemy);
                    }
                }
            }
        }

        private void GetFreeze(Enemy.Enemy currentEnemy)
        {
            switch (currentEnemy.FreezeStacks)
            {
                case 0:
                {
                    currentEnemy.Speed = currentEnemy.SpeedBeforefreeze;
                    break;
                }
                case > 0:
                {
                    currentEnemy.Speed = currentEnemy.SpeedBeforefreeze - currentEnemy.SpeedBeforefreeze * (freezePower * currentEnemy.FreezeStacks);
                    CheckMinimumSpeed(_currentEnemy);
                    break;
                }
            }
        }

        private void UnFreeze(Enemy.Enemy currentEnemy)
        {
            currentEnemy.FreezeStacks = 0;
            currentEnemy.Speed = currentEnemy.SpeedBeforefreeze;
        }

        private void FreezeStacks()
        {
            _currentEnemy.FreezeStacks++;
        }

        private void CheckMinimumSpeed(Enemy.Enemy currentEnemy)
        {
            if (currentEnemy.Speed < currentEnemy.MinimumSpeed)
            {
                currentEnemy.Speed = currentEnemy.MinimumSpeed;
            }
        }
    }
}
