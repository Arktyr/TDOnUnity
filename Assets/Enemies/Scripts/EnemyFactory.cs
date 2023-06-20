using Configs.Scripts;
using UnityEngine;

namespace Enemies.Scripts
{
    public class EnemyFactory : MonoBehaviour
    {
        [SerializeField] private EnemyPool _enemyPool;

        public Enemy CreateEnemy(EnemyConfig config, Vector3 position)
        {
            if (_enemyPool.IsCreate == false) _enemyPool.CreatePool(config.Enemy);

            Enemy enemy = _enemyPool.TakeFromPool(config.Enemy, position);
            
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
