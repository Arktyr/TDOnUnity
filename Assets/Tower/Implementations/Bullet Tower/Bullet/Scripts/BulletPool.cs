using Implementations.BaseTowerLogic;
using Object_Pools.Scripts;


namespace Implementations.Bullet_Tower.Bullet.Scripts
{
    public class BulletPool : BasePool<BulletBase>
    {
        private void Start() => Construct(RemoveFromEvent, AddToEvent);

        private void AddToEvent(BulletBase bullet) => bullet.OnDestroy += ReturnToPool;

        private void RemoveFromEvent(BulletBase bullet) => bullet.OnDestroy -= ReturnToPool;
    }
}