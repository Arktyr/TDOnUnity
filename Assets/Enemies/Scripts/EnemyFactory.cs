using Configs.Scripts;
using UnityEngine;

namespace Enemies.Scripts
{
    public class EnemyFactory : MonoBehaviour
    {
        [SerializeField] private EnemyPool _enemyPool;

        private EnemyAilmentsConfig _enemyAilmentsConfig;

        private void OnEnable() => _enemyPool.PoolExpanded += CreateEnemyAilments;

        private void OnDisable() => _enemyPool.PoolExpanded -= CreateEnemyAilments;

        public Enemy CreateEnemy(EnemyConfig config, Vector3 position)
        {
            _enemyAilmentsConfig = config.EnemyAilmentsConfig;

            if (_enemyPool.IsCreate == false)
            {
                _enemyPool.CreatePool(config.Enemy);
                
                CreateEnemyAilments(config.Enemy);
            }
            
            Enemy enemy = _enemyPool.TakeFromPool(config.Enemy, position);
            
            enemy.Construct(config.Health,
                config.Speed,
                config.MoneyReward,
                config.MaximumSlowPercent,
                config.Path,
                config.DeathAnimation);

            return enemy;
        }

        private void CreateEnemyAilments(Enemy enemy)
        {
            foreach (var Enemy in _enemyPool.enemyPool)
            {
                if (Enemy.FreezeAilment != null) return;
                
                FreezeAilment freezeAilment = Instantiate(_enemyAilmentsConfig.FreezeAilment, Enemy.transform);
                Enemy.ConstructEnemyAilments(freezeAilment);
            }
        }
    }
}
