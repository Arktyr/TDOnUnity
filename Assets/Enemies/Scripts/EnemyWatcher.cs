using System;
using UnityEngine;
using Wave.Scripts;

namespace Enemies.Scripts
{
    public class EnemyWatcher : MonoBehaviour
    {
        [SerializeField] private WaveSpawner _waveSpawner;
        
        public event Action <Enemy> EnemyKilled;
        public event Action EnemySpawned;
        public event Action EnemyFinishedPath;

        private void OnEnable() => _waveSpawner.EnemySpawned += OnEnemySpawn;

        private void OnDestroy() => _waveSpawner.EnemySpawned -= OnEnemySpawn;

        private void OnEnemySpawn(Enemy enemy)
        {
            if (enemy != null)
            {
                enemy.OnKill += OnEnemyKill;
                enemy.FinishedThePath += OnEnemyFinishedThePath;
            }
            
            EnemySpawned?.Invoke();
        }

        private void OnEnemyFinishedThePath(Enemy enemy)
        {
            enemy.FinishedThePath -= OnEnemyFinishedThePath;
         
            EnemyFinishedPath?.Invoke();
        }

        private void OnEnemyKill(Enemy enemy)
        {
            enemy.OnKill -= OnEnemyKill;
            
            EnemyKilled?.Invoke(enemy);
        }
    }
}