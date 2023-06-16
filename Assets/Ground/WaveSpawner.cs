using System.Collections;
using UI.Scripts;
using UnityEngine;

namespace Ground
{
    public class Wavespawner : MonoBehaviour 
    {
        [SerializeField] private Wave[] waves;
        [SerializeField] private WaveCounter waveCounter;
        private int _currentWaveIndex;
        private int _enemiesLeftToSpawn;
        private int _currentSettings;
        private float _spawnEnemyDelay;
        private int _settingsCount;
        private bool _isDelay;
        public float CurrentDelayBeforeNextWave => waves[_currentWaveIndex].DelayBeforeNextWave;
        public int CurrentWaveIndex => _currentWaveIndex;
        
        
        private void Start()
        {
            _enemiesLeftToSpawn = waves[0].Settings[0].EnemyCount;
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
                if (_currentWaveIndex < waves.Length - 1)
                {
                    if (_isDelay == false) StartCoroutine(DelayBeforeNextWave(waves[_currentWaveIndex].DelayBeforeNextWave));
                }
            }
        }

        private void SpawnCurrentEnemy()
        {
            Instantiate(waves[_currentWaveIndex].Settings[_currentSettings].EnemyGameObject, transform.position, Quaternion.identity);
            _enemiesLeftToSpawn--;
            StartCoroutine(SpawnWave());
        }

        private void NextSettingsEnemyInWave()
        {
            _currentSettings++;
            _enemiesLeftToSpawn = waves[_currentWaveIndex].Settings[_currentSettings].EnemyCount;
            StartCoroutine(SpawnWave());
        }

        private void NextWave()
        {
            _currentWaveIndex++;
            waveCounter.ChangeWaveCounter.Invoke();
            _currentSettings = 0;
            _enemiesLeftToSpawn = waves[_currentWaveIndex].Settings[_currentSettings].EnemyCount;
            StartCoroutine(SpawnWave()); 
        }

        private void PrepareForSpawnEnemy()
        {
            _spawnEnemyDelay = waves[_currentWaveIndex].Settings[_currentSettings].SpawnDelay;
            _settingsCount = waves[_currentWaveIndex].Settings.Length;
        }

        private IEnumerator DelayBeforeNextWave(float delay)
        {
            waveCounter.NextWave.Invoke();
            _isDelay = true;
            yield return new WaitForSeconds(delay);
            _isDelay = false;
            NextWave();
        }
    }
}