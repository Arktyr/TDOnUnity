using System.Collections.Generic;
using System.Linq;
using UI.Scripts;
using UnityEngine;

namespace Enemy
{
    public class EnemyWatcher : MonoBehaviour
    {
        [SerializeField] private EnemyCounter enemyCounter;
        [SerializeField] private MoneyCounter moneyCounter;
        private List<EnemyController> _enemyCount;

        private void Start()
        {
            _enemyCount = new List<EnemyController>();
        }

        private void Update()
        {
            OnEnemyKill();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out EnemyController enemyController))
            {
                OnEnemySpawn(enemyController);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.TryGetComponent(out EnemyController enemyController))
            {
                OnEnemyFinishedThePath(enemyController);
            }
        }

        private void OnEnemySpawn(EnemyController enemyController)
        {
            enemyCounter.OnEnemySpawn.Invoke();
            _enemyCount.Add(enemyController);
        }

        private void OnEnemyFinishedThePath(EnemyController enemyController)
        {
            _enemyCount.Remove(enemyController);
            enemyCounter.OnEnemyFinish.Invoke();
        }

        private void OnEnemyKill()
        {
            if (_enemyCount.Count != 0)
            {
                for (int i = 0; i < _enemyCount.Count; i++)
                {
                    if (_enemyCount.ElementAt(i) == null)
                    {
                        moneyCounter.GetRewardFromEnemy(_enemyCount.ElementAt(i));
                        _enemyCount.Remove(_enemyCount.ElementAt(i));
                        enemyCounter.OnEnemyKill.Invoke();
                    }
                }
            }
        }
    }
}