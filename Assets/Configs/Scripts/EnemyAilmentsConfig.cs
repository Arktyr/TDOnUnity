using Enemies.Scripts;
using UnityEngine;

namespace Configs.Scripts
{
    [CreateAssetMenu(fileName = "EnemyAilmentConfig", menuName = "Configs/EnemyAilmentConfig")]
    public class EnemyAilmentsConfig : ScriptableObject
    {
        [SerializeField] private FreezeAilment freezeAilment;
        
        public FreezeAilment FreezeAilment => freezeAilment;
    }
}