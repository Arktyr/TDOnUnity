using Enemies.Scripts;
using UnityEngine;

namespace Player_Manager.Scripts
{
    public class LifeManager : MonoBehaviour
    {
        [SerializeField] private EnemyWatcher _enemyWatcher;
        
        [Header("Start Life")]
        [SerializeField] private float _life;
        
        private void OnEnable() => _enemyWatcher.EnemyFinishedPath += ReducingLife;
        
        private void OnDisable() => _enemyWatcher.EnemyFinishedPath -= ReducingLife;
        
        private void ReducingLife()
        {
            _life--;
            
            if (_life <= 0) GameOver();
        }

        private void GameOver() => Time.timeScale = 0;
    }
}
