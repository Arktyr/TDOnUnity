using System;
using System.Collections;
using System.Linq;
using Configs.Scripts;
using Implementations.BaseTowerLogic;
using Implementations.Bullet_Tower.Bullet.Scripts;
using UnityEngine;

namespace Implementations.Bullet_Tower.Tower.Scripts
{
    public class BulletTower : BaseAttackTower
    {
        private BulletFactory _bulletFactory;
        private BulletControllerConfig _bulletControllerConfig;
    
        private float _bulletRateOfFire;

        private bool _isFire;

        public float BulletRateOfFire => _bulletRateOfFire;

        private event Action Fire;

        public void Construct(BulletFactory bulletFactory, BulletControllerConfig bulletControllerConfig, float towerDamage,
            float bulletRateOfFire, float price)
        {
            _bulletFactory = bulletFactory;
            _bulletControllerConfig = bulletControllerConfig;
            _towerDamage = towerDamage;
            _bulletRateOfFire = bulletRateOfFire;
            _price = price;
        }
    
        private void FixedUpdate()
        {
            if (CheckingEnemyCount())
            {
                if (_isFire == false) StartCoroutine(FireRate());
                
                LookAtEnemy();
            }
        }

        private BulletBase BulletCreate()
        {
            Vector3 target = EnemyInRadius.First().transform.position;
            Vector3 towerWeaponPosition = transform.GetChild(0).position;
            
            BulletBase currentBullet = _bulletFactory.CreateBullet(_bulletControllerConfig, _towerDamage,  
                towerWeaponPosition, target);

            Fire += currentBullet.BulletMovement;

            return currentBullet;
        }
        
        private void BulletFire()
        {
            BulletBase currentBullet = BulletCreate();
                
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

        public void SetRateOfFire(float RateOfFire) => _bulletRateOfFire = RateOfFire;
    }
}
