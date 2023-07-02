using Object_Pools.Scripts;

namespace Enemies.Scripts
{
    public class EnemyPool : BasePool<EnemyBase>
    {
        private void Start() => Construct(RemoveFromEvent, AddToEvent);
        
        private void AddToEvent(EnemyBase enemyBase) => enemyBase.OnKill += ReturnToPool;

        private void RemoveFromEvent(EnemyBase enemyBase) => enemyBase.OnKill -= ReturnToPool;
    }
}