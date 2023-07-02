using Enemies.Scripts;
using UI.Scripts;
using UnityEngine;

namespace Player_Manager.Scripts
{
    public class RewardManager : MonoBehaviour
    {
        [SerializeField] private EnemyWatcher _enemyWatcher;
        
        [SerializeField] private MoneyManager _moneyManager;
        [SerializeField] private MoneyCounterUI _moneyCounterUI;

        private void OnEnable() => _enemyWatcher.EnemyKilled += GetRewardFromEnemy;

        private void OnDisable() => _enemyWatcher.EnemyKilled += GetRewardFromEnemy;

        private void GetRewardFromEnemy(EnemyBase enemyBase)
        {
            float _reward = enemyBase.MoneyReward;
            
            _moneyCounterUI.PlayAnimation(_reward);
            
            _moneyManager.AddMoney(_reward);
        }
    }
}
