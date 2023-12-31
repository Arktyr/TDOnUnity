using Enemies.Scripts;
using UnityEngine;

namespace Configs.Scripts
{
    [CreateAssetMenu (fileName = "EnemyConfig", menuName = "Configs/EnemyConfig")]
    public class EnemyConfig : ScriptableObject
    {
        [SerializeField] private EnemyBase enemyBase;
        [SerializeField] private float _health;
        [SerializeField] private float _speed;
        [SerializeField] private float _moneyReward;
        [SerializeField] private float _maximumSlowPercents;
        [SerializeField] private Transform _path;
        [SerializeField] private DeathAnimation _deathAnimation;

        public EnemyBase EnemyBase => enemyBase;
        
        public float Health => _health;
        
        public float Speed => _speed;
        
        public float MoneyReward => _moneyReward;

        public float MaximumSlowPercent => _maximumSlowPercents;
        
        public Transform Path => _path; 
        
        public DeathAnimation DeathAnimation => _deathAnimation;
    }
}
