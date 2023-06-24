using Object_Pools.Scripts;
using UnityEngine;

namespace Implementations.Bullet_Tower.Bullet.Scripts
{
    public class BulletPool : BasePool<BulletController>
    {
        private void Start() => Construct(CreateEnemy, SetDisable, SetActive, RemoveFromEvent, AddToEvent, SetTransform);
        
        private BulletController CreateEnemy(BulletController bullet) => Instantiate(bullet, transform.parent);

        private void SetActive(BulletController bullet) => bullet.gameObject.SetActive(true);

        private void SetDisable(BulletController bullet) => bullet.gameObject.SetActive(false);

        private void SetTransform(BulletController bullet, Vector3 position) => bullet.transform.position = position;

        private void AddToEvent(BulletController bullet) => bullet.OnDestroy += ReturnToPool;

        private void RemoveFromEvent(BulletController bullet) => bullet.OnDestroy -= ReturnToPool;
    }
}