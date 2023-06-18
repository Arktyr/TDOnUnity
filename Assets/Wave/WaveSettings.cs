﻿using Configs;
using UnityEngine;

namespace Wave
{
    [System.Serializable]
    public class WaveSettings
    {
        [SerializeField] private EnemyConfig enemyConfig;
        public EnemyConfig EnemyConfig => enemyConfig;
        
        [SerializeField] private int enemyCount;
        public int EnemyCount => enemyCount;
        [SerializeField] private float spawnDelay;
        public float SpawnDelay => spawnDelay;
    }
}