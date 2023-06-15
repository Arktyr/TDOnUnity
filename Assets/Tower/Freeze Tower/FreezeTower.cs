using System;
using System.Linq;
using Tower;
using Enemy;
using UnityEngine;
using UnityEngine.Assertions.Must;

namespace Freeze_Tower
{
    public class FreezeTower : BaseTower
    {
        private float _freezeTowerDamage;
        private float _freezingPower;
        public float freezePower;
        private bool _isAttack;
        private float _freezeStacks;
        private EnemyController _currentEnemy;

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
            if (other.TryGetComponent(out EnemyController enemyController))
            {
                enemyController.inRadius++;
            }
        }
        
        protected override void OnTriggerExit(Collider other)
        {
            
            if (other.TryGetComponent(out EnemyController enemyController))
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
                if (_currentEnemy == null || _currentEnemy != EnemyInRadius.ElementAt(IntCheckingEnemyInRadius()).GetComponent<EnemyController>())
                {
                    _isAttack = false;
                    _currentEnemy = EnemyInRadius.ElementAt(IntCheckingEnemyInRadius()).GetComponent<EnemyController>();
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

        private void GetFreeze(EnemyController currentEnemy)
        {
            switch (currentEnemy.freezeStacks)
            {
                case 0:
                {
                    currentEnemy.speed = currentEnemy.speedBeforefreeze;
                    break;
                }
                case > 0:
                {
                    Debug.Log(currentEnemy.freezeStacks);
                    currentEnemy.speed = currentEnemy.speedBeforefreeze - currentEnemy.speedBeforefreeze * (freezePower * currentEnemy.freezeStacks);
                    CheckMinimumSpeed(_currentEnemy);
                    break;
                }
            }
        }

        private void UnFreeze(EnemyController currentEnemy)
        {
            currentEnemy.freezeStacks = 0;
            currentEnemy.speed = currentEnemy.speedBeforefreeze;
        }

        private void FreezeStacks()
        {
            _currentEnemy.freezeStacks++;
        }

        private void CheckMinimumSpeed(EnemyController currentEnemy)
        {
            if (currentEnemy.speed < currentEnemy.minimumSpeed)
            {
                currentEnemy.speed = currentEnemy.minimumSpeed;
            }
        }
    }
}
