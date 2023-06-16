using Configs;
using UnityEngine;

namespace Enemy
{
    public class EnemyFactory : MonoBehaviour
    {
        public void CreateEnemy(EnemyConfig enemyConfig, Vector3 pos)
        {
            EnemyController enemy  = Instantiate(enemyConfig.Enemy, pos, Quaternion.identity);
            enemy.Construct(enemyConfig.Path, enemyConfig.Points, enemyConfig.Speed, enemyConfig.Health,enemyConfig.MoneyReward);
        }
    }
}
