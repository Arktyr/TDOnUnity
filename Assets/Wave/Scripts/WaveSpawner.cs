using System;
using System.Collections;
using Enemies.Scripts;
using UI.Scripts;
using UnityEngine;

namespace Wave.Scripts
{
    public class WaveSpawner : MonoBehaviour 
    {
        [SerializeField] private Wave[] _waves;
        [SerializeField] private EnemyFactory _enemyFactory;

        private int _currentWaveIndex;
        private int _currentSettings;
        private int _settingsCount;
        
        private int _enemiesLeftToSpawn;
        private float _spawnEnemyDelay;
        private bool _isDelay;

        public event Action<EnemyBase> EnemySpawned;
        public event Action WaveHasChanged;
        public event Action StartCountDownToNewWave;
        
        public float CurrentDelayBeforeNextWave => _waves[_currentWaveIndex].DelayBeforeNextWave;
        
        public int CurrentWaveIndex => _currentWaveIndex;
        
        private void Start()
        {
            _enemiesLeftToSpawn = _waves[0].Settings[0].EnemyCount;
            StartCoroutine(SpawnWave());
        }

        private IEnumerator SpawnWave()
        {
            PrepareForSpawnEnemy();
            if (_enemiesLeftToSpawn > 0)
            {
                yield return new WaitForSeconds(_spawnEnemyDelay);
                SpawnCurrentEnemy();
            }
            if (_settingsCount > 0 && _settingsCount != _currentSettings + 1)
            {
                NextSettingsEnemyInWave();
            }
            if (_settingsCount == _currentSettings + 1 && _enemiesLeftToSpawn == 0)
            {
                if (_currentWaveIndex < _waves.Length - 1)
                {
                    if (_isDelay == false) StartCoroutine(DelayBeforeNextWave(_waves[_currentWaveIndex].DelayBeforeNextWave));
                }
            }
        }

        private void SpawnCurrentEnemy()
        {
            EnemyBase enemyBase = _enemyFactory.CreateEnemy(_waves[_currentWaveIndex].Settings[_currentSettings].EnemyConfig,
                transform.position);
            EnemySpawned?.Invoke(enemyBase);
            _enemiesLeftToSpawn--;
            StartCoroutine(SpawnWave());
        }

        private void NextSettingsEnemyInWave()
        {
            _currentSettings++;
            _enemiesLeftToSpawn = _waves[_currentWaveIndex].Settings[_currentSettings].EnemyCount;
            StartCoroutine(SpawnWave());
        }

        private void NextWave()
        {
            _currentWaveIndex++;
            WaveHasChanged?.Invoke();
            _currentSettings = 0;
            _enemiesLeftToSpawn = _waves[_currentWaveIndex].Settings[_currentSettings].EnemyCount;
            StartCoroutine(SpawnWave()); 
        }

        private void PrepareForSpawnEnemy()
        {
            _spawnEnemyDelay = _waves[_currentWaveIndex].Settings[_currentSettings].SpawnDelay;
            _settingsCount = _waves[_currentWaveIndex].Settings.Length;
        }

        private IEnumerator DelayBeforeNextWave(float delay)
        {
            StartCountDownToNewWave?.Invoke();
            _isDelay = true;
            yield return new WaitForSeconds(delay);
            _isDelay = false;
            NextWave();
        }
    }
}