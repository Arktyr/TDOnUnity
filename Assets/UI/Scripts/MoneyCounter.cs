using System;
using Enemy;
using TMPro;
using UnityEngine;

namespace UI.Scripts
{
    public class MoneyCounter : MonoBehaviour
    {
        [SerializeField] private TMP_Text text;
        [SerializeField] private float startMoney;
        private float _money;
        public float Money => _money;
        private float _reward;

        private void Start()
        {
            _money = startMoney;
            ChangeTextInMoneyCounterUI();
        }

        public void GetMoney()
        {
            _money += _reward;
            ChangeTextInMoneyCounterUI();
        }

        public void GetRewardFromEnemy(EnemyController enemyController)
        {
            _reward = enemyController.moneyReward;
        }

        private void ChangeTextInMoneyCounterUI()
        {
            text.SetText($"{_money}");
        }

        public void BuyTower(float price)
        {
            _money -= price;
            ChangeTextInMoneyCounterUI();
        }
    }
}
