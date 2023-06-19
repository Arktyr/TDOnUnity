using Enemies.Scripts;
using UnityEngine;

namespace Configs.Scripts
{
    [CreateAssetMenu(fileName = "EnemyAilmentConfig", menuName = "Configs/EnemyAilmentConfig")]
    public class EnemyAilmentsConfig : ScriptableObject
    {
        [SerializeField] private EnemyAilments _enemyAilments;
        [SerializeField] private Freeze _freeze;

        public EnemyAilments EnemyAilments => _enemyAilments;
        public Freeze Freeze => _freeze;
    }
}