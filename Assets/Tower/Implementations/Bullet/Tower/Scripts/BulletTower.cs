using System.Collections;
using System.Linq;
using Configs.Scripts;
using Implementations.Bullet.Bullet.Scripts;
using UnityEngine;

namespace Implementations.Bullet.Tower.Scripts
{
public class BulletTower : BaseTower.BaseTower
{
    private BulletControllerConfig _bulletControllerConfig;
    private BulletFactory _bulletFactory;
    private float _bulletRateOfFire;
    private float _bulletSpeed;
    private float _bulletTowerDamage;
    private bool _checkFireRate;
    private float _spawnTime;
    private BulletController _newBullet;
    private Rigidbody _bulletRigidBody;

    public void Construct(BulletFactory bulletFactory, float bulletRateOfFire, float bulletTowerDamage, BulletControllerConfig bulletControllerConfig)
    {
        _bulletControllerConfig = bulletControllerConfig;
        _bulletFactory = bulletFactory;
        _bulletRateOfFire = bulletRateOfFire;
        _bulletTowerDamage = bulletTowerDamage;
    }
    
    
    
    private void FixedUpdate()
    {
        if (CheckingEnemyCount() && _checkFireRate == false)
        {
            StartCoroutine(FireRate());
        }
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
        else
        {
            RemoveEnemyIfKill();
        }
    }


    private IEnumerator FireRate()
    {
        _checkFireRate = true;
        BulletFire();
        yield return new WaitForSeconds(_bulletRateOfFire);
        if (CheckingEnemyCount())
        {
            StartCoroutine(FireRate());
        }
        else
        {
            _checkFireRate = false;
        }
    }

    private void BulletCreate()
    {
        if (BoolCheckingEnemyInRadius())
        {
            _bulletFactory.ConstructConfig(_bulletControllerConfig);
            _bulletFactory.TakeFromPool( transform.GetChild(0).position, EnemyInRadius.ElementAt(IntCheckingEnemyInRadius()).transform.position, _bulletTowerDamage, _bulletFactory);
        }
    }
}
}
