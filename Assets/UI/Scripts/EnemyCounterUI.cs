using Enemies.Scripts;
using UI.Animations;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Scripts
{
    public class EnemyCounterUI : MonoBehaviour
    {
        [SerializeField] private Text _text;
        [SerializeField] private EnemyWatcher _enemyWatcher;
        [SerializeField] private ScaleUIAnimation _scaleUIAnimation;
      
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
            _scaleUIAnimation.PlayAnimation(_text);
            _leftEnemy++;
            ChangeTextInEnemyCounterUI();
        }

        private void CounterDown(EnemyBase enemyBase)
        {
            _scaleUIAnimation.PlayAnimation(_text);
            _leftEnemy--;
            ChangeTextInEnemyCounterUI();
        }
        
        private void ChangeTextInEnemyCounterUI() => _text.text = $"{_leftEnemy}";
    }
}