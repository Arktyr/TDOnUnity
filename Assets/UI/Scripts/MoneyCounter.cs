using Enemy;
using TMPro;
using UnityEngine;

namespace UI.Scripts
{
    public class MoneyCounter : MonoBehaviour
    {
        [SerializeField] private TMP_Text text;
        private float _money;
        private float _reward;

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
    }
}