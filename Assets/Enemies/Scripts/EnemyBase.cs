using System;
using System.Collections;
using Interfaces;
using UnityEngine;

namespace Enemies.Scripts
{
    [RequireComponent(typeof(Rigidbody), typeof(SphereCollider), 
        typeof(FreezeAilment))]
    public abstract class EnemyBase : MonoBehaviour, IDamageable

    {
    private FreezeAilment _freezeAilment;

    public float _health;
    private float _speed;
    private float _moneyReward;
    private float _minimumSpeed;
    private float _startSpeed;

    private Transform _path;
    private Transform[] _pathPoints;
    private int _currentPoint;

    private Rigidbody _enemyRigidBody;
    private SphereCollider _sphereCollider;
    private DeathAnimation _deathAnimation;
    private bool _isDead;
    
    public float Speed => _speed;
    
    public float MoneyReward => _moneyReward;
    
    public FreezeAilment FreezeAilment => _freezeAilment;
    
    public virtual void Construct(float health,
        float speed,
        float moneyReward,
        Transform path,
        float maximumSlowPercents,
        DeathAnimation deathAnimation)
    {
        _health = health;
        _speed = speed;
        _moneyReward = moneyReward;
        _path = path;
        _minimumSpeed = speed - (speed * maximumSlowPercents);
        _deathAnimation = deathAnimation;
        _startSpeed = _speed;
    }

    public event Action<EnemyBase> OnKill;
    public event Action<EnemyBase> OnKillForTower;
    public event Action<EnemyBase> FinishedThePath;

    protected virtual void Start()
    {
        _sphereCollider = GetComponent<SphereCollider>();
        _enemyRigidBody = GetComponent<Rigidbody>();
        _freezeAilment = GetComponent<FreezeAilment>();
    }

    protected virtual void FixedUpdate()
    {
        if (_path != null && gameObject.activeSelf) GetPathPoints();

        EnemyMove();
    }

    protected virtual void GetPathPoints()
    {
        _pathPoints = new Transform[_path.childCount];

        for (int i = 0; i < _pathPoints.Length; i++) _pathPoints[i] = _path.GetChild(i);
    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out EnemyPath enemyPath))
        {
            if (enemyPath._EndPath)
            {
                FinishedThePath?.Invoke(this);
                Destroy(gameObject);
            }

            _currentPoint++;
        }
    }

    protected virtual void EnemyMove()
    {
        if (_pathPoints != null)
        {
            Vector3 position = _enemyRigidBody.transform.position;
            Vector3 currentPointPosition = _pathPoints[_currentPoint].position;

            Vector3 direction = -(position - currentPointPosition).normalized;
            Vector3 velocity = direction * (_speed * Time.fixedDeltaTime);

            _enemyRigidBody.velocity = velocity;
        }
    }

    public virtual void TakeDamage(float damage)
    {
        _health -= damage;
        if (damage <= 0) Debug.LogError("Damage should be above zero");

        if (_health <= 0 && _isDead == false) StartCoroutine(EnemyKill());
    }

    public virtual void SetSpeed(float speed) => _speed = speed;

    public virtual bool CheckMinimumSpeed()
    {
        if (_speed < _minimumSpeed)
        {
            SetSpeed(_minimumSpeed);
            return true;
        }

        return false;
    }

    protected virtual void ResetEnemy()
    {
        _currentPoint = 0;
        SetSpeed(_startSpeed);

        OnKill?.Invoke(this);
    }

    protected virtual IEnumerator EnemyKill()
    {
        _isDead = true;
        _sphereCollider.enabled = false;
        OnKillForTower?.Invoke(this);

        _deathAnimation.PlayAnimation(this, 0);
        yield return new WaitForSeconds(_deathAnimation.ScaleDuration);

        _deathAnimation.PlayAnimation(this, 5);

        ResetEnemy();

        _sphereCollider.enabled = true;
        _isDead = false;
    }
    
    }
}
