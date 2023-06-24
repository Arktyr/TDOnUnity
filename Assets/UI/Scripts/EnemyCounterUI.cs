using System;
using Enemies.Scripts;
using TMPro;
using UI.Animations;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Scripts
{
    public class EnemyCounterUI : MonoBehaviour
    {
        [SerializeField] private Text _text;
        [SerializeField] private EnemyWatcher _enemyWatcher;
        [SerializeField] private EnemyCounterUIAnimation _enemyCounterUIAnimation;
      
        private float _leftEnemy;
        
        private void OnEnable()
        {
            _enemyWatcher.EnemySpawned += CounterUp;
            _enemyWatcher.EnemyKilled += CounterDown;
        }

        private void OnDisable()
        {
            _enemyWatcher.EnemySpawned -= CounterUp;
            _enemyWatcher.EnemyKilled -= CounterDown;
        }

        private void CounterUp()
        {
            _enemyCounterUIAnimation.PlayAnimation(_text);
            _leftEnemy++;
            ChangeTextInEnemyCounterUI();
        }

        private void CounterDown(Enemy enemy)
        {
            _enemyCounterUIAnimation.PlayAnimation(_text);
            _leftEnemy--;
            ChangeTextInEnemyCounterUI();
        }
        
        private void ChangeTextInEnemyCounterUI() => _text.text = $"{_leftEnemy}";
    }
}