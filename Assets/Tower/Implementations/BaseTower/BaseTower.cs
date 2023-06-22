using System;
using System.Collections.Generic;
using System.Linq;
using Enemies.Scripts;
using UnityEngine;

namespace Implementations.BaseTower
{
    public abstract class BaseTower : MonoBehaviour
    {
        protected LineRenderer LaserLine;

        private bool _checkEnemyInRadius;
        private bool _checkEnemyCount;

        protected readonly List<Enemy> EnemyInRadius = new();

        private event Action<Enemy> EnterInRadius;     
        private event Action<Enemy> ExitFromRadius;

        protected void OnEnable()
        {
            EnterInRadius += AddEnemyInRadius;
            ExitFromRadius += RemoveEnemyFromRadius;
        }

        protected void OnDestroy()
        {
            EnterInRadius -= AddEnemyInRadius;
            ExitFromRadius -= RemoveEnemyFromRadius;
        }
        
        protected virtual void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Enemy enemy))
            {
                EnterInRadius?.Invoke(enemy);
                enemy.OnKillForTower += RemoveEnemyFromRadius;
            }
        }
        
        protected virtual void OnTriggerExit(Collider other)
        {
            if (other.TryGetComponent(out Enemy enemy)) ExitFromRadius?.Invoke(enemy);
        }

        protected virtual void LaserFire(float damage)
        {
            SetPositionLaser(EnemyInRadius.First());
            
            EnemyInRadius.First().TakeDamage(damage);
        }

        protected bool CheckingEnemyCount() => EnemyInRadius.Count > 0;

        protected void SetPositionLaser(bool check)
        {
            switch (check)
            {
                case true: 
                    Vector3 target = EnemyInRadius.First().transform.position;
                    
                    LaserLine.SetPosition(1, target);
                    break;
                
                case false:
                    Vector3 towerWeaponPosition = transform.GetChild(0).position;
                    
                    LaserLine.SetPosition(0, towerWeaponPosition);
                    LaserLine.SetPosition(1, towerWeaponPosition);
                    break;
            }
        }

        private void AddEnemyInRadius(Enemy enemy) => EnemyInRadius.Add(enemy);

        private void RemoveEnemyFromRadius(Enemy enemy)
        {
            enemy.OnKillForTower -= RemoveEnemyFromRadius;
            
            EnemyInRadius.Remove(enemy);
        }
    }
}




