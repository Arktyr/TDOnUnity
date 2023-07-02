using Enemies.Scripts;
using Implementations.BaseTowerLogic;
using UnityEngine;

namespace Implementations.AOE_Tower.Scripts
{
    public class AOEBullet : BulletBase
    {
        protected void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out EnemyBase enemyBase)) enemyBase.TakeDamage(_bulletDamage);
        }
    }
}