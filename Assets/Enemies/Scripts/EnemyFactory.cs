using Configs.Scripts;
using UnityEngine;

namespace Enemies.Scripts
{
    public class EnemyFactory : MonoBehaviour
    {
        [SerializeField] private EnemyPool _enemyPool;
        
        public EnemyBase CreateEnemy(EnemyConfig config, Vector3 position)
        {
            if (_enemyPool.IsCreate == false) _enemyPool.CreatePool(config.EnemyBase);

            EnemyBase enemyBase = _enemyPool.TakeFromPool(config.EnemyBase, position);
            
            enemyBase.Construct(config.Health,
                config.Speed,
                config.MoneyReward,
                config.Path,
                config.MaximumSlowPercent,
                config.DeathAnimation);

            return enemyBase;
        }
    }
}
