using System.Collections.Generic;
using UnityEngine;

namespace Enemies.Scripts
{
    public class EnemyPool : MonoBehaviour
    {
        [SerializeField] private float startCountEnemyPool;

        private bool _isCreate;
        private int _currentEnemyCount;
        
        private readonly Queue<Enemy> _enemyPool = new();
        private readonly Queue<Enemy> _activeEnemies = new();

        public bool IsCreate => _isCreate;
        
        public void CreatePool(Enemy enemy)
        {
            _isCreate = true;
            
            for (int i = 0; i < startCountEnemyPool; i++)
            {
                Enemy newEnemy = Instantiate(enemy, transform.parent);

                _enemyPool.Enqueue(newEnemy);
                newEnemy.gameObject.SetActive(false);
            }
        }

        public Enemy TakeFromPool(Enemy enemy, Vector3 position)
        {
            if (_enemyPool.Count == 0) AddToPool(enemy);
            
            _activeEnemies.Enqueue(_enemyPool.Dequeue());
            
            _activeEnemies.Peek().OnKill += ReturnToPool;
            _activeEnemies.Peek().gameObject.SetActive(true);
            _activeEnemies.Peek().transform.position = position;
            
            return _activeEnemies.Dequeue();
        }

        private void ReturnToPool(Enemy enemy)
        {
            enemy.OnKill -= ReturnToPool;
            
            _enemyPool.Enqueue(enemy);
            enemy.gameObject.SetActive(false);
        }

        private void AddToPool(Enemy enemy)
        {
            Enemy newEnemy = Instantiate(enemy, transform.parent);
            
            _enemyPool.Enqueue(newEnemy);
        }
    }
}