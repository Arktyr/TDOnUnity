using UnityEngine;

namespace Ground
{
    [System.Serializable]
    public class WaveSettings
    {
        [SerializeField] private GameObject enemyGameObject;
        public GameObject EnemyGameObject => enemyGameObject;
        [SerializeField] private int enemyCount;
        public int EnemyCount => enemyCount;
        [SerializeField] private float spawnDelay;
        public float SpawnDelay => spawnDelay;
    }
}