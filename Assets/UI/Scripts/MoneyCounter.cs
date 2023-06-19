using Enemies.Scripts;
using TMPro;
using UI.Animations;
using UnityEngine;

namespace UI.Scripts
{
    public class MoneyCounter : MonoBehaviour
    {
        [SerializeField] private TMP_Text text;
        [SerializeField] private float startMoney;
        [SerializeField] private MoneyCounterAnimation moneyCounterAnimation;
        private float _money;
        private Vector3 _startPosition;
        public float Money => _money;
        private float _reward;

        private void Start()
        {
            _startPosition = moneyCounterAnimation.animatedText.transform.position;
            _money = startMoney;
            ChangeTextInMoneyCounterUI();
        }

        public void GetMoney()
        {
            if (moneyCounterAnimation.isMoveAnimationStart == false)
            {
                moneyCounterAnimation.animatedText.transform.position = _startPosition;
                moneyCounterAnimation.PlayAnimation(_reward);
            }
            else
            {
                moneyCounterAnimation.reward += _reward;
                moneyCounterAnimation.SetText();
            }
            _money += _reward;
            ChangeTextInMoneyCounterUI();
        }

        public void GetRewardFromEnemy(Enemy enemy)
        {
            _reward = enemy.MoneyReward;
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
