using Object_Pools.Scripts;

namespace Enemies.Scripts
{
    public class EnemyPool : BasePool<Enemy>
    {
        private void Start() => Construct(RemoveFromEvent, AddToEvent);
        
        private void AddToEvent(Enemy enemy) => enemy.OnKill += ReturnToPool;

        private void RemoveFromEvent(Enemy enemy) => enemy.OnKill -= ReturnToPool;
    }
}