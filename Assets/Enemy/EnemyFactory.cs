using Configs;
using UnityEngine;

namespace Enemy
{
    public class EnemyFactory : MonoBehaviour
    {
        public void CreateEnemy(EnemyConfig config, Vector3 position)
        {
            Enemy enemy  = Instantiate(config.Enemy, position, Quaternion.identity);
            
            enemy.Construct(config.Path, config.Points, config.Speed, 
                config.Health, config.MoneyReward, config.EnemyDeathAnimator);
        }
    }
}
