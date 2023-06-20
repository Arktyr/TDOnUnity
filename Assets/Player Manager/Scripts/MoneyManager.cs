using System;
using UI.Scripts;
using UnityEngine;

namespace Player_Manager.Scripts
{
    public class MoneyManager : MonoBehaviour
    {
        [SerializeField] private MoneyCounter _moneyCounter; 

        [Header("Start Money")]
        [SerializeField] private float _money;

        public float Money => _money;

        private void Start() => _moneyCounter.ChangeTextInMoneyCounterUI(_money);

        public void AddMoney(float money) => _money += money;

        private void RemoveMoney(float money) => _money -= money;

        public void BuyTower(float money)
        {
            RemoveMoney(money);
            _moneyCounter.ChangeTextInMoneyCounterUI(_money);
        }
    }
}
