using UnityEngine;

namespace Enemy
{
    public class EnemyController : MonoBehaviour
    {
        private Transform _path;
        private Transform[] _points;
        private float _health;
        private Rigidbody _enemyRigidBody;
        private int _currentPoint;
        [HideInInspector]public float speed;
        [HideInInspector]public float moneyReward;
        [HideInInspector]public float minimumSpeed;
        [HideInInspector]public float speedBeforefreeze;
        [HideInInspector]public float freezeStacks;
        [HideInInspector]public int inRadius;
        
        public void Construct(Transform Path, Transform[] Points, float Speed, float Health, float MoneyReward )
        {
            _path = Path;
            _points = Points;
            speed = Speed;
            _health = Health;
            moneyReward = MoneyReward;
            minimumSpeed = speed - (speed*0.65f);
            speedBeforefreeze = speed;
            _enemyRigidBody = GetComponent<Rigidbody>();
            GetPoints();
        }

        private void FixedUpdate()
        {
            EnemyMove();
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.TryGetComponent(out EnemyPath enemyPath))
            {
                if (enemyPath._EndPath)
                {
                    Destroy(gameObject);
                }
                _currentPoint++;
            }
        }
        
        private void EnemyMove()
        {
            Vector3 velocity = (_enemyRigidBody.transform.position - _points[_currentPoint].position).normalized;
            _enemyRigidBody.velocity = -velocity * (speed * Time.fixedDeltaTime);
        }

        public void TakeDamage(float damage)
        {
            _health -= damage;
            if (_health <= 0)
            {
                Destroy(gameObject);
            }
        }

        private void GetPoints()
        {
            _points = new Transform[_path.childCount];
            for (int i = 0; i < _points.Length; i++)
            {
                _points[i] = _path.GetChild(i);
            }
        }
    }
}
