using Enemies.Scripts;
using Implementations.BaseTowerLogic;
using UnityEngine;

namespace Implementations.Bullet_Tower.Bullet.Scripts
{
    public class Bullet : BulletBase
    {
        protected override void OnCollisionEnter(Collision other)
        {
            if (other.collider.TryGetComponent(out EnemyBase enemyBase))
            {
                enemyBase.TakeDamage(_bulletDamage);
                base.OnCollisionEnter(other);
            }
        }
    }
}