using System;
using System.Collections;
using UnityEngine;

namespace Enemy
{
    [RequireComponent(typeof(Rigidbody))]
    public class Enemy : MonoBehaviour
    {
        const float MinSpeedPercent = 0.65f;

        [HideInInspector] public float Speed;
        [HideInInspector] public float MoneyReward;
        [HideInInspector] public float MinimumSpeed;
        [HideInInspector] public float SpeedBeforefreeze;
        [HideInInspector] public float FreezeStacks;
        [HideInInspector] public int inRadius;

        private bool _isDead;

        private Transform _path;
        private Transform[] _pathPoints;
        private int _currentPointCount;

        private Rigidbody _enemyRigidBody;
        private EnemyDeathAnimator _enemyDeathAnimator;
        
        public void Construct(float speed,
            float moneyReward,
            float health,
            Transform path,
            Transform[] pathPoints,
            EnemyDeathAnimator enemyDeathAnimator)
        {
            Speed = speed;
            SpeedBeforefreeze = speed;
            
            MoneyReward = moneyReward;
            
            Health = health;
            _path = path;
            _pathPoints = pathPoints;
            
            _enemyDeathAnimator = enemyDeathAnimator;
            
            _enemyRigidBody = GetComponent<Rigidbody>();
            
            MinimumSpeed = speed - speed * MinSpeedPercent;
        }
        
        public float Health { get; private set; }

        public event Action<Enemy> Died;
        public event Action<Enemy> FinishedThePath;
        
        
        private void Awake() => 
            GetPoints();

        private void FixedUpdate() => 
            EnemyMove();

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.TryGetComponent(out EnemyPath enemyPath))
            {
                if (enemyPath._EndPath)
                {
                    FinishedThePath?.Invoke(this);
                    Destroy(gameObject);
                }
                _currentPointCount++;
            }
        }

        private void GetPoints()
        {
            _pathPoints = new Transform[_path.childCount];
            
            for (int i = 0; i < _pathPoints.Length; i++)
            {
                _pathPoints[i] = _path.GetChild(i);
            }
        }

        public void TakeDamage(float damage)
        {
            if (damage <= 0) 
                Debug.Log("Damage should be above zero");

            Health -= damage;
            
            if (Health <= 0)
            {
                if (_isDead == false) 
                    StartCoroutine(Death());
            }
        }

        private void EnemyMove()
        {
            Vector3 position = _enemyRigidBody.transform.position;
            Vector3 currentPointPosition = _pathPoints[_currentPointCount].position;
            
            Vector3 direction = - (position - currentPointPosition).normalized;
            Vector3 velocity = direction * (Speed * Time.fixedDeltaTime);
                
            _enemyRigidBody.velocity = velocity;
        }

        private IEnumerator Death()
        {
            _isDead = true;
            _enemyDeathAnimator.PlayScaleAnimation(gameObject);
            yield return new WaitForSeconds(_enemyDeathAnimator.ScaleDuration);

            Died?.Invoke(this);
            Destroy(gameObject);
        }
    }
}
