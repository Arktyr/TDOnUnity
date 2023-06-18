using System.Collections;
using System.Linq;
using Configs;
using Implementations.Bullet.Bullet;
using UnityEngine;

namespace Implementations.Bullet.Tower
{
public class BulletTower : BaseTower
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
    
    private void FireBullet()
    {
        if (CheckingEnemy())
        {
            CreateBullet();
            LastEnemy = EnemyInRadius.ElementAt(GetFirstEnemyIndex());
        }
        else
        {
            RemoveEnemyIfKill();
        }
    }
    
    private IEnumerator FireRate()
    {
        _checkFireRate = true;
        FireBullet();
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

    private void CreateBullet()
    {
        if (IsEnemyInRadius())
        {
            _bulletFactory.ConstructConfig(_bulletControllerConfig);
            _bulletFactory.TakeFromPool( transform.GetChild(0).position, EnemyInRadius.ElementAt(GetFirstEnemyIndex()).transform.position, _bulletTowerDamage, _bulletFactory);
        }
    }
}
}
