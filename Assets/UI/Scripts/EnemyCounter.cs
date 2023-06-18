using Enemy;
using TMPro;
using UnityEngine;

namespace UI.Scripts
{
    public class EnemyCounter : MonoBehaviour
    {
        [SerializeField] private TMP_Text text;
        [SerializeField] private EnemyWatcher _enemyWatcher;
        
        private float _leftEnemy;

        private void OnEnable()
        {
            _enemyWatcher.EnemySpawned += CounterUp;
            _enemyWatcher.EnemyKilled += CounterDown;
            _enemyWatcher.EnemyFinishedPath += CounterDown;
        }

        private void OnDisable()
        {
            _enemyWatcher.EnemySpawned -= CounterUp;
            _enemyWatcher.EnemyKilled -= CounterDown;
            _enemyWatcher.EnemyFinishedPath -= CounterDown;
        }

        private void CounterUp(Enemy.Enemy enemy)
        {
            _leftEnemy++;
            ChangeTextInEnemyCounterUI();
        }

        private void CounterDown(Enemy.Enemy enemy)
        {
            _leftEnemy--;
            ChangeTextInEnemyCounterUI();
        }
        
        private void ChangeTextInEnemyCounterUI() => 
            text.SetText($"Enemies Left: {_leftEnemy}");
    }
}