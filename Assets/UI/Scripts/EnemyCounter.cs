using System;
using TMPro;
using UnityEngine;

namespace UI.Scripts
{
    public class EnemyCounter : MonoBehaviour
    {
        [SerializeField] private TMP_Text text;
        public Action OnEnemySpawn;
        public Action OnEnemyKill;
        private float _leftEnemy;

        private void OnEnable()
        {
            OnEnemySpawn += CounterUp;
            OnEnemyKill += CounterDown;
        }

        private void OnDisable()
        {
            OnEnemySpawn -= CounterUp;
            OnEnemyKill -= CounterDown;
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