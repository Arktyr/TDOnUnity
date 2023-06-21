using System.Collections;
using System.Linq;
using Configs.Scripts;
using Implementations.Bullet_Tower.Bullet.Scripts;
using UnityEngine;

namespace Implementations.Bullet_Tower.Tower.Scripts
{
    public class BulletTower : BaseTower.BaseTower
    {
        private BulletFactory _bulletFactory;
        private BulletControllerConfig _bulletControllerConfig;
    
        private float _bulletRateOfFire;

        private bool _checkFireRate;

        public void Construct(BulletFactory bulletFactory, BulletControllerConfig bulletControllerConfig, float bulletRateOfFire)
        {
            _bulletFactory = bulletFactory;
            _bulletControllerConfig = bulletControllerConfig;
            _bulletRateOfFire = bulletRateOfFire;
        }
    
        private void FixedUpdate()
        {
            if (CheckingEnemyCount() && _checkFireRate == false) StartCoroutine(FireRate());
        }

        protected override void OnTriggerStay(Collider other)
        {
            base.OnTriggerStay(other);
        
            for (int i = 0; i < EnemyInRadius.Count; i++)
            {
                if (EnemyInRadius.ElementAt(i) != null)
                {
                    transform.LookAt(EnemyInRadius.ElementAt(i).transform.position);
                    break;
                }
            }
        }
        
        private void BulletFire()
        {
            if (CheckingEnemy())
            {
                BulletCreate();
                LastEnemy = EnemyInRadius.ElementAt(IntCheckingEnemyInRadius());
            }
            else RemoveEnemyIfKill();
        }
    
        private IEnumerator FireRate()
        {
            _checkFireRate = true;
        
            BulletFire();
            yield return new WaitForSeconds(_bulletRateOfFire);
        
            if (CheckingEnemyCount()) StartCoroutine(FireRate());
            else _checkFireRate = false;
        }

        private void BulletCreate() => _bulletFactory.CreateBullet(_bulletControllerConfig, transform.GetChild(0).position,
            EnemyInRadius.ElementAt(IntCheckingEnemyInRadius()).transform.position);
    }
}
