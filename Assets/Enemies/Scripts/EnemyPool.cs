using Object_Pools.Scripts;
using UnityEngine;

namespace Enemies.Scripts
{
    public class EnemyPool : BasePool<Enemy>
    {
        private void Start() => Construct(CreateEnemy, SetDisable, SetActive, RemoveFromEvent, AddToEvent, SetTransform);
        
        private Enemy CreateEnemy(Enemy enemy) => Instantiate(enemy, transform.parent);

        private void SetActive(Enemy enemy) => enemy.gameObject.SetActive(true);

        private void SetDisable(Enemy enemy) => enemy.gameObject.SetActive(false);

        private void SetTransform(Enemy enemy, Vector3 position) => enemy.transform.position = position;

        private void AddToEvent(Enemy enemy) => enemy.OnKill += ReturnToPool;

        private void RemoveFromEvent(Enemy enemy) => enemy.OnKill -= ReturnToPool;
    }
}