using Enemy;
using UnityEngine;

namespace UI.Scripts
{
    public class MoneyService : MonoBehaviour
    {
        [SerializeField] private EnemyWatcher _enemyWatcher;
        
        private float _money;

        private void OnEnable() => 
            _enemyWatcher.EnemyKilled += AccureRewardFromEnemy;

        private void OnDisable() => 
            _enemyWatcher.EnemyKilled -= AccureRewardFromEnemy;

        public void AddMoney(float amount)
        {
            if (amount < 0)
            {
                Debug.LogError("");
                return;
            }
        }
        
        public bool TrySpendMoney(float amount)
        {
            if (amount < 0)
            {
                Debug.LogError("");
                return false;
            }

            _money -= amount;
            return true;
        }
        
        private void AccureRewardFromEnemy(Enemy.Enemy enemy) => 
            _money += enemy.MoneyReward;
    }
}