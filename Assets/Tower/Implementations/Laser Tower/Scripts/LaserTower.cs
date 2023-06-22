using UnityEngine;

namespace Implementations.Laser_Tower.Scripts
{
    [RequireComponent(typeof(LineRenderer))]
    public class LaserTower : BaseTower.BaseTower
    {
        private float _laserTowerDamage;

        public void Construct(float laserTowerDamage) => _laserTowerDamage = laserTowerDamage;

        protected void Start()
        {
            Transform towerWeapon = transform.GetChild(0);
            LaserLine = towerWeapon.GetComponent<LineRenderer>();
        }

        private void FixedUpdate()
        {
            if (CheckingEnemyCount()) LaserFire(_laserTowerDamage);
            
            else SetPositionLaser(false);
        }
    }
}
