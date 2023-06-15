using UnityEngine;
using Tower;

namespace Laser_Tower
{
    public class LaserTower : BaseTower
    {
        private float _laserTowerDamage;

        public void Construct(float laserTowerDamage)
        {
            _laserTowerDamage = laserTowerDamage;
        }
    
        protected override void Start()
        {
            base.Start();
            LaserLine = transform.GetChild(0).GetComponent<LineRenderer>();
        }

        private void FixedUpdate()
        {
            if (CheckingEnemy())
            {
                LaserFire(_laserTowerDamage);
            }
            else
            {
                SetPositionLaser(false);
            }
        }
    }
}
