using UI.Scripts;
using UnityEngine;

namespace Player_Manager.Scripts
{
    public class MoneyManager : MonoBehaviour
    {
        [SerializeField] private MoneyCounterUI moneyCounterUI;

        [Header("Start Money")]
        [SerializeField] private float _money;

        public float Money => _money;

        private void Start() => moneyCounterUI.ChangeTextInMoneyCounterUI(_money);

        public void AddMoney(float money)
        {
            _money += money;
            moneyCounterUI.ChangeTextInMoneyCounterUI(_money);
        }

        public void RemoveMoney(float money)
        {
            _money -= money;
            moneyCounterUI.ChangeTextInMoneyCounterUI(_money);
        }
    }
}
