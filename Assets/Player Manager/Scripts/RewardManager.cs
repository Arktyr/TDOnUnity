using System;
using Enemies.Scripts;
using UI.Animations;
using UI.Scripts;
using UnityEngine;

namespace Player_Manager.Scripts
{
    public class RewardManager : MonoBehaviour
    {
        [SerializeField] private EnemyWatcher _enemyWatcher;
        
        [SerializeField] private MoneyManager _moneyManager;
        [SerializeField] private MoneyCounter _moneyCounter;

        private void OnEnable()
        {
            _enemyWatcher.EnemyKilled += GetRewardFromEnemy;
        }

        private void OnDisable()
        {
            _enemyWatcher.EnemyKilled += GetRewardFromEnemy;
        }
        
        private void GetRewardFromEnemy(Enemy enemy)
        {
            float _reward = enemy.MoneyReward;
            
            _moneyCounter.PlayAnimation(_reward);
            
            _moneyManager.AddMoney(_reward);
            
            _moneyCounter.ChangeTextInMoneyCounterUI(_moneyManager.Money);
        }
    }
}
