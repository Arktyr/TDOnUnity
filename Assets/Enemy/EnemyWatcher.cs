using System;
using System.Collections.Generic;
using UnityEngine;
using Wave;

namespace Enemy
{
    public class EnemyWatcher : MonoBehaviour
    {
        [SerializeField] private WaveSpawner _waveSpawner;
        
        private readonly List<Enemy> _leftEnemy = new();

        public event Action<Enemy> EnemySpawned;
        public event Action<Enemy> EnemyKilled;
        public event Action<Enemy> EnemyFinishedPath;

        private void OnEnable() => 
            _waveSpawner.EnemySpawned += OnEnemySpawned;

        private void OnDisable()
        {
            _waveSpawner.EnemySpawned -= OnEnemySpawned;

            foreach (Enemy enemy in _leftEnemy)
            {
                enemy.FinishedThePath -= OnEnemyFinishedPath;
                enemy.Died -= OnEnemyKilled;
            }
        }

        private void OnEnemySpawned(Enemy enemy)
        {
            _leftEnemy.Add(enemy);
            EnemySpawned?.Invoke(enemy);

            enemy.FinishedThePath += OnEnemyFinishedPath;
            enemy.Died += OnEnemyKilled;
        }

        private void OnEnemyFinishedPath(Enemy enemy)
        {
            enemy.FinishedThePath -= OnEnemyFinishedPath;
            
            _leftEnemy.Remove(enemy);
            EnemyFinishedPath?.Invoke(enemy);
        }

        private void OnEnemyKilled(Enemy enemy)
        {
            enemy.Died -= OnEnemyKilled;
            
            _leftEnemy.Remove(enemy);
            EnemyKilled?.Invoke(enemy);
        }
    }
}