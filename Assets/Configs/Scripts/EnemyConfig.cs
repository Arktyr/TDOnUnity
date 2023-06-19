using Enemy.Scripts;
using UnityEngine;

namespace Configs.Scripts
{
    [CreateAssetMenu (fileName = "EnemyConfig", menuName = "Configs/EnemyConfig")]
    public class EnemyConfig : ScriptableObject
    {
        [SerializeField] private EnemyController enemy;
        [SerializeField] private DeathAnimation deathAnimation;
        [SerializeField] private Transform path;
        [SerializeField] private Transform[] points;
        [SerializeField] private float speed;
        [SerializeField] private float health;
        [SerializeField] private float moneyReward;
        public EnemyController Enemy => enemy;
        public DeathAnimation DeathAnimation => deathAnimation;
        public Transform Path => path;
        public Transform[] Points => points;
        public float Speed => speed;
        public float Health => health;
        public float MoneyReward => moneyReward;
    }
}
