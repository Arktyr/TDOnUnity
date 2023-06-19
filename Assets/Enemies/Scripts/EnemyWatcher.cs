using System;
using UnityEngine;
using Wave.Scripts;

namespace Enemies.Scripts
{
    public class EnemyWatcher : MonoBehaviour
    {
        [SerializeField] private Wavespawner _waveSpawner;
        
        public event Action EnemyKilled;
        public event Action EnemySpawned;
        public event Action EnemyFinishedPath;

        private void OnEnable()
        {
            _waveSpawner.EnemySpawned += OnEnemySpawn;
        }

        private void OnDestroy()
        {
            _waveSpawner.EnemySpawned -= OnEnemySpawn;
        }
        
        private void OnEnemySpawn(Enemy enemy)
        {
            enemy.OnKill += OnEnemyKill;
            enemy.FinishedThePath += OnEnemyFinishedThePath;
            
            EnemySpawned?.Invoke();
        }

        private void OnEnemyFinishedThePath(Enemy enemy)
        {
            enemy.FinishedThePath -= OnEnemyFinishedThePath;
         
            EnemyFinishedPath?.Invoke();
        }

        private void OnEnemyKill(Enemy enemy)
        {
            // _moneyCounter.GetRewardFromEnemy(_leftEnemy.ElementAt(i));
            enemy.OnKill -= OnEnemyKill;
            
            EnemyKilled?.Invoke();
        }
    }
}