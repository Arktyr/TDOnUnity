using Enemy;
using UnityEngine;

namespace Configs
{
    [CreateAssetMenu (fileName = "EnemyConfig", menuName = "Configs/EnemyConfig")]
    public class EnemyConfig : ScriptableObject
    {
        [SerializeField] private Enemy.Enemy enemy;
        [SerializeField] private EnemyDeathAnimator _enemyDeathAnimator;
        [SerializeField] private Transform path;
        [SerializeField] private Transform[] points;
        [SerializeField] private float speed;
        [SerializeField] private float health;
        [SerializeField] private float moneyReward;
        
        public Enemy.Enemy Enemy => enemy;
        public EnemyDeathAnimator EnemyDeathAnimator => _enemyDeathAnimator;
        public Transform Path => path;
        public Transform[] Points => points;
        public float Speed => speed;
        public float Health => health;
        public float MoneyReward => moneyReward;
    }
}
