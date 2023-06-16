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
        public static float Money;
        private float _lastMoney;
        private float _reward;

        private void Start()
        {
            Money = startMoney;
        }

        private void Update()
        {
            if (_lastMoney != Money)
            {
                ChangeTextInMoneyCounterUI();
                _lastMoney = Money;
            }
        }

        public void GetMoney()
        {
            Money += _reward;
            _lastMoney = Money;
            ChangeTextInMoneyCounterUI();
        }

        public void GetRewardFromEnemy(EnemyController enemyController)
        {
            _reward = enemyController.moneyReward;
        }

        private void ChangeTextInMoneyCounterUI()
        {
            text.SetText($"{Money}");
        }

        public static void BuyTower(float price)
        {
            Money -= price;
        }
    }
}
