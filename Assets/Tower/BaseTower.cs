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
    private GameObject _lastEnemy;



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
            if (_lastEnemy != EnemyInRadius.ElementAt(IntCheckingEnemyInRadius()) && _lastEnemy != null)
            {
                EnemyInRadius.Remove(_lastEnemy);
            }
            EnemyInRadius.ElementAt(IntCheckingEnemyInRadius()).GetComponent<EnemyController>().TakeDamage(damage);
            _lastEnemy = EnemyInRadius.ElementAt(IntCheckingEnemyInRadius());
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




