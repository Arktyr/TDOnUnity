using System;
using Freeze_Tower;
using UnityEngine;

namespace Enemy
{
    public class EnemyController : MonoBehaviour
    {
        [SerializeField] private Transform path;
        [SerializeField] private Transform[] points;
        [SerializeField] public float speed;
        [SerializeField] private float health;
        private Rigidbody _enemyRigidBody;
        private int _currentPoint;                              
        [HideInInspector]public float minimumSpeed;
        [HideInInspector]public float speedBeforefreeze;
        [HideInInspector]public float freezeStacks;
        [HideInInspector]public int inRadius;
        
        private void Start()
        {
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
            Vector3 velocity = (_enemyRigidBody.transform.position - points[_currentPoint].position).normalized;
            _enemyRigidBody.velocity = -velocity * (speed * Time.fixedDeltaTime);
        }

        public void TakeDamage(float damage)
        {
            health -= damage;
            if (health <= 0)
            {
                Destroy(gameObject);
            }
        }

        private void GetPoints()
        {
            points = new Transform[path.childCount];
            for (int i = 0; i < points.Length; i++)
            {
                points[i] = path.GetChild(i);
            }
        }
    }
}
