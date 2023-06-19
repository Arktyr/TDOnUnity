using System;
using System.Collections;
using UnityEngine;

namespace Enemies.Scripts
{
    [RequireComponent(typeof(Rigidbody))]
    public class Enemy : MonoBehaviour
    {
        private float _health;
        public float _speed;
        private float _moneyReward;
        private float _minimumSpeed;
        private float _startSpeed;

        private Transform _path;
        private Transform[] _pathPoints;
        private int _currentPoint;
        
        private Rigidbody _enemyRigidBody;
        private DeathAnimation _deathAnimation;
        private bool _isDead;

        private EnemyAilments _enemyAilments;

        public float Health => _health;
        
        public float MoneyReward => _moneyReward;
        
        public float StartSpeed => _startSpeed;
        
        public EnemyAilments EnemyAilments => _enemyAilments;

        public void Construct(float health,
            float speed,
            float moneyReward,
            float maximumSlowPercents,
            Transform path,
            DeathAnimation deathAnimation,
            EnemyAilments enemyAilments)
        {
            _health = health;
            _speed = speed;
            _moneyReward = moneyReward; 
            _minimumSpeed = speed - (speed*maximumSlowPercents);
            _path = path;
            _deathAnimation = deathAnimation;
            _enemyAilments = enemyAilments;
            _startSpeed = _speed;
        }
        
        public event Action<Enemy> OnKill;
        public event Action<Enemy> FinishedThePath;

        private void Start()
        {
            _enemyRigidBody = GetComponent<Rigidbody>();

            GetPathPoints();
        }

        private void FixedUpdate()
        {
            EnemyMove();
        }

        private void GetPathPoints()
        {
            _pathPoints = new Transform[_path.childCount];
            
            for (int i = 0; i < _pathPoints.Length; i++)
            {
                _pathPoints[i] = _path.GetChild(i);
            }
        }
        
        private void OnTriggerEnter(Collider other)
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
        
        private void EnemyMove()
        {
            Vector3 position = _enemyRigidBody.transform.position;
            Vector3 currentPointPosition = _pathPoints[_currentPoint].position;
            
            Vector3 direction = -(position - currentPointPosition).normalized;
            Vector3 velocity = direction * (_speed * Time.fixedDeltaTime);
            
            _enemyRigidBody.velocity = velocity;
        }

        public void TakeDamage(float damage)
        {
            _health -= damage;

            if (damage <= 0)
            {
                Debug.LogError("Damage should be above zero");
            }
            
            if (_health <= 0)
            {
                
                if (_isDead == false)
                {
                    StartCoroutine(Death());
                }
            }
        }

        public void SetSpeed(float speed)
        {
            _speed = speed;
        }
        
        public void CheckMinimumSpeed()
        {
            if (_speed < _minimumSpeed)
            {
                SetSpeed(_minimumSpeed);
            }
        }
        
        private IEnumerator Death()
        {
            _isDead = true;
            _deathAnimation.PlayAnimation(gameObject);
            yield return new WaitForSeconds(_deathAnimation.ScaleDuration);
            
            OnKill?.Invoke(this);
            Destroy(gameObject);
        }
    }
}
