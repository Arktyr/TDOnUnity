using Enemy;
using UnityEngine;

namespace Configs
{
    [CreateAssetMenu (fileName = "EnemyConfig", menuName = "Configs/EnemyConfig")]
    public class EnemyConfig : ScriptableObject
    {
        [SerializeField] private EnemyController enemy;
        [SerializeField] private Transform path;
        [SerializeField] private Transform[] points;
        [SerializeField] private float speed;
        [SerializeField] private float health;
        [SerializeField] private float moneyReward;
        public EnemyController Enemy => enemy;
        public Transform Path => path;
        public Transform[] Points => points;
        public float Speed => speed;
        public float Health => health;
        public float MoneyReward => moneyReward;
    }
}
