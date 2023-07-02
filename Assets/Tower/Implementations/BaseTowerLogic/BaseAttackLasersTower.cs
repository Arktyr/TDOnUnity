using System.Linq;
using UnityEngine;

namespace Implementations.BaseTowerLogic
{
    public abstract class BaseAttackLasersTower : BaseAttackTower
    {
        protected LineRenderer LaserLine;
        
        protected virtual void LaserFire(float damage)
        {
            SetPositionLaser(EnemyInRadius.First());
            
            EnemyInRadius.First().TakeDamage(damage);
        }
        
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
    }
}