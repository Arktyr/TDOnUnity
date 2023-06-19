using Configs.Scripts;
using UnityEngine;

namespace Enemies.Scripts
{
    public class EnemyFactory : MonoBehaviour
    {
        public Enemy CreateEnemy(EnemyConfig config, Vector3 position)
        {
            Enemy enemy = Instantiate(config.Enemy, position, Quaternion.identity);
            
            enemy.Construct(config.Health,
                config.Speed,
                config.MoneyReward,
                config.MaximumSlowPercent,
                config.Path,
                config.DeathAnimation,
                CreateEnemyAilment(config.EnemyAilmentsConfig, enemy));

            return enemy;
        }

        private EnemyAilments CreateEnemyAilment(EnemyAilmentsConfig enemyAilmentsConfig, Enemy enemy)
        {
            EnemyAilments enemyAilments = Instantiate(enemyAilmentsConfig.EnemyAilments, enemy.transform);
            Freeze freeze = Instantiate(enemyAilmentsConfig.Freeze, enemyAilments.transform, true);
            
            enemyAilments.SetFreeze(freeze);
            
            enemyAilments.transform.parent = enemy.transform;
            
            return enemyAilments;
        }
    }
}
