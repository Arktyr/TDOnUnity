using Implementations.BaseTowerLogic;
using UnityEngine;

namespace Implementations.Laser_Tower.Scripts
{
    [RequireComponent(typeof(LineRenderer))]
    public class LaserTower : BaseAttackLasersTower
    {
        public void Construct(float laserTowerDamage, float price)
        {
            _towerDamage = laserTowerDamage;
            _price = price;
        }

        protected void Start()
        {
            Transform towerWeapon = transform.GetChild(0);
            LaserLine = towerWeapon.GetComponent<LineRenderer>();
        }

        private void FixedUpdate()
        {
            if (CheckingEnemyCount()) LaserFire(_towerDamage);
            
            else SetPositionLaser(false);
        }
    }
}
