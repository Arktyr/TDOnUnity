using System.Collections;
using System.Linq;
using Bullet_Tower;
using Tower;
using UnityEngine;

namespace Bullet_Tower
{
public class BulletTower : BaseTower
{
    private BulletController _bullet;
    private float _bulletRateOfFire;
    private float _bulletSpeed;
    private float _bulletTowerDamage;
    private bool _checkFireRate;
    private float _spawnTime;
    private BulletController _newBullet;
    private Rigidbody _bulletRigidBody;

    public void Construct(BulletController bullet, float bulletSpeed, float bulletRateOfFire, float bulletTowerDamage)
    {
        _bullet = bullet;
        _bulletRateOfFire = bulletRateOfFire;
        _bulletSpeed = bulletSpeed;
        _bulletTowerDamage = bulletTowerDamage;
    }
    
    private void FixedUpdate()
    {
        if (CheckingEnemyCount() && _checkFireRate == false)
        {
            StartCoroutine(FireRate());
        }
    }

    protected void OnTriggerStay(Collider other)
    {
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
        }
        else
        {
            EnemyInRadius.Remove(EnemyInRadius.First());
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
        _newBullet = Instantiate(_bullet, transform.GetChild(0).position, Quaternion.identity);
        _newBullet.gameObject.GetComponent<BulletController>().bulletTowerDamage = _bulletTowerDamage;
        BulletMovement();
    }

    private void BulletMovement()
    {
        if (BoolCheckingEnemyInRadius())
        {
            _bulletRigidBody = _newBullet.GetComponent<Rigidbody>();
            Vector3 velocity = (_newBullet.transform.position - EnemyInRadius.ElementAt(IntCheckingEnemyInRadius()).transform.position).normalized;
            _bulletRigidBody.velocity = -velocity * (_bulletSpeed * Time.fixedDeltaTime);
        }
    }
}
}
