using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Enemy;
using UnityEngine;

namespace Tower
{
public abstract class BaseTower : MonoBehaviour
{
    protected List<GameObject> EnemyInRadius;
    protected LineRenderer LaserLine;
    private bool _checkEnemyInRadius;
    private bool _checkEnemyCount;
    protected GameObject LastEnemy;



    protected virtual void Start()
    {
        EnemyInRadius = new List<GameObject>();
    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out EnemyController enemyController))
        {
            EnemyInRadius.Add(other.gameObject);
        }
    }
    
    protected virtual void OnTriggerExit(Collider other)
    {
       EnemyInRadius.Remove(other.gameObject);
    }

    protected virtual void LaserFire(float damage)
    {
        SetPositionLaser(CheckingEnemy());
        if (BoolCheckingEnemyInRadius())
        {
            RemoveEnemyIfKill();
            EnemyInRadius.ElementAt(IntCheckingEnemyInRadius()).GetComponent<EnemyController>().TakeDamage(damage);
            LastEnemy = EnemyInRadius.ElementAt(IntCheckingEnemyInRadius());
        }
    }

    protected int IntCheckingEnemyInRadius()
    {
        for (int i = 0; i < EnemyInRadius.Count; i++)
        {
            if (EnemyInRadius.ElementAt(i) != null)
            {
                return i;
            }
        }
        return 0;
    }
    protected bool BoolCheckingEnemyInRadius()
    {
        for (int i = 0; i < EnemyInRadius.Count; i++)
        {
            if (EnemyInRadius.ElementAt(i) != null)
            {
                return true;
            }
        }
        return false;
    }

    protected bool CheckingEnemy()
    {
        _checkEnemyCount = CheckingEnemyCount();
        _checkEnemyInRadius = BoolCheckingEnemyInRadius();
        if (_checkEnemyInRadius == _checkEnemyCount && _checkEnemyCount)
        {
            return  true;
        }
        return false;
    }
    
    protected bool CheckingEnemyCount()
    {
        _checkEnemyCount = EnemyInRadius.Count > 0;
        return _checkEnemyCount;
    }

    protected void RemoveEnemyIfKill()
    {
        if (LastEnemy != EnemyInRadius.ElementAt(IntCheckingEnemyInRadius()) && LastEnemy != null)
        {
            EnemyInRadius.Remove(LastEnemy);
        }
    }
    
    protected void SetPositionLaser(bool check)
    {
        switch (check)
        {
            case true:
            {
                LaserLine.SetPosition(1, EnemyInRadius.ElementAt(IntCheckingEnemyInRadius()).transform.position);
                break;
            }
            case false:
            {
                LaserLine.SetPosition(0, transform.GetChild(0).position);
                LaserLine.SetPosition(1, transform.GetChild(0).position);
                break;
            }
        }
    }
}
}




