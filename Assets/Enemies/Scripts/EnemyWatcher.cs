using System;
using UnityEngine;
using Wave.Scripts;

namespace Enemies.Scripts
{
    public class EnemyWatcher : MonoBehaviour
    {
        [SerializeField] private WaveSpawner _waveSpawner;
        
        public event Action <EnemyBase> EnemyKilled;
        public event Action EnemySpawned;
        public event Action EnemyFinishedPath;

        private void OnEnable() => _waveSpawner.EnemySpawned += OnEnemySpawn;

        private void OnDestroy() => _waveSpawner.EnemySpawned -= OnEnemySpawn;

        private void OnEnemySpawn(EnemyBase enemyBase)
        {
            if (enemyBase != null)
            {
                enemyBase.OnKill += OnEnemyKill;
                enemyBase.FinishedThePath += OnEnemyFinishedThePath;
            }
            
            EnemySpawned?.Invoke();
        }

        private void OnEnemyFinishedThePath(EnemyBase enemyBase)
        {
            enemyBase.FinishedThePath -= OnEnemyFinishedThePath;
         
            EnemyFinishedPath?.Invoke();
        }

        private void OnEnemyKill(EnemyBase enemyBase)
        {
            enemyBase.OnKill -= OnEnemyKill;
            
            EnemyKilled?.Invoke(enemyBase);
        }
    }
}