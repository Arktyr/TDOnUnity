using Object_Pools.Scripts;


namespace Implementations.Bullet_Tower.Bullet.Scripts
{
    public class BulletPool : BasePool<BulletController>
    {
        private void Start() => Construct(RemoveFromEvent, AddToEvent);

        private void AddToEvent(BulletController bullet) => bullet.OnDestroy += ReturnToPool;

        private void RemoveFromEvent(BulletController bullet) => bullet.OnDestroy -= ReturnToPool;
    }
}