using System;
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

        private bool _isFire;

        private event Action Fire;

        public void Construct(BulletFactory bulletFactory, BulletControllerConfig bulletControllerConfig, float bulletRateOfFire)
        {
            _bulletFactory = bulletFactory;
            _bulletControllerConfig = bulletControllerConfig;
            _bulletRateOfFire = bulletRateOfFire;
        }
    
        private void FixedUpdate()
        {
            if (CheckingEnemyCount())
            {
                if (_isFire == false) StartCoroutine(FireRate());
                
                LookAtEnemy();
            }
        }

        private BulletController BulletCreate()
        {
            Vector3 target = EnemyInRadius.First().transform.position;
            Vector3 towerWeaponPosition = transform.GetChild(0).position;
            
            BulletController currentBullet = _bulletFactory.CreateBullet(_bulletControllerConfig, 
                towerWeaponPosition, target);

            Fire += currentBullet.BulletMovement;

            return currentBullet;
        }
        
        private void BulletFire()
        {
            BulletController currentBullet = BulletCreate();
                
            Fire?.Invoke();
            Fire -= currentBullet.BulletMovement;
        }
        
        private void LookAtEnemy() => transform.LookAt(EnemyInRadius.First().transform);
        
        private IEnumerator FireRate()
        {
            _isFire = true;
        
            BulletFire();
            yield return new WaitForSeconds(_bulletRateOfFire);

            _isFire = false;
        }
    }
}
