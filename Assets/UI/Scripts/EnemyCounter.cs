using System;
using DG.Tweening;
using TMPro;
using UnityEngine;

namespace UI.Scripts
{
    public class EnemyCounter : MonoBehaviour
    {
        [SerializeField] private TMP_Text text;
        [SerializeField] private MoneyCounter moneyCounter;
        public Action OnEnemySpawn;
        public Action OnEnemyKill;
        public Action OnEnemyFinish;
        private float _leftEnemy;

        private void OnEnable()
        {
            OnEnemySpawn += CounterUp;
            OnEnemyKill += CounterDown;
            OnEnemyKill += moneyCounter.GetMoney;
            OnEnemyFinish += CounterDown;
        }

        private void OnDisable()
        {
            OnEnemySpawn -= CounterUp;
            OnEnemyKill -= CounterDown;
            OnEnemyKill -= moneyCounter.GetMoney;
            OnEnemyFinish -= CounterDown;
        }

        private void CounterUp()
        {
            _leftEnemy++;
            ChangeTextInEnemyCounterUI();
        }

        private void CounterDown()
        {
            _leftEnemy--;
            ChangeTextInEnemyCounterUI();
        }
        
        private void ChangeTextInEnemyCounterUI()
        {
            text.SetText($"Enemies Left:  {_leftEnemy}");
        }
    }
}