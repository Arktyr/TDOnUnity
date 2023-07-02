using System;
using System.Collections.Generic;
using Enemies.Scripts;
using UnityEngine;

namespace Implementations.BaseTowerLogic
{
    public abstract class BaseAttackTower : BaseTower
    {
        public float _towerDamage;
        
        private bool _checkEnemyInRadius;
        private bool _checkEnemyCount;

        protected readonly List<EnemyBase> EnemyInRadius = new();

        private event Action<EnemyBase> EnterInRadius;     
        private event Action<EnemyBase> ExitFromRadius;

        public float TowerDamage => _towerDamage;
        
        protected virtual void OnEnable()
        {
            EnterInRadius += AddEnemyInRadius;
            ExitFromRadius += RemoveEnemyFromRadius;
        }

        protected virtual void OnDestroy()
        {
            EnterInRadius -= AddEnemyInRadius;
            ExitFromRadius -= RemoveEnemyFromRadius;
        }
        
        protected virtual void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out EnemyBase enemy))
            {
                EnterInRadius?.Invoke(enemy);
                enemy.OnKillForTower += RemoveEnemyFromRadius;
            }
        }
        
        protected virtual void OnTriggerExit(Collider other)
        {
            if (other.TryGetComponent(out EnemyBase enemy)) ExitFromRadius?.Invoke(enemy);
        }
        
        protected bool CheckingEnemyCount() => EnemyInRadius.Count > 0;
        
        private void AddEnemyInRadius(EnemyBase enemyBase) => EnemyInRadius.Add(enemyBase);

        private void RemoveEnemyFromRadius(EnemyBase enemyBase)
        {
            enemyBase.OnKillForTower -= RemoveEnemyFromRadius;
            
            EnemyInRadius.Remove(enemyBase);
        }
        
        public void SetDamage(float damage) => _towerDamage = damage;
    }
}




