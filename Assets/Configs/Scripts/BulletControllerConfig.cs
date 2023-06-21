using Implementations.Bullet_Tower.Bullet.Scripts;
using UnityEngine;

namespace Configs.Scripts
{
    [CreateAssetMenu(fileName = "BulletControllerConfig", menuName = "Configs/BulletControllerConfig")]
    public class BulletControllerConfig : ScriptableObject
    {
        [SerializeField] private BulletController _bulletController;
        [SerializeField] private float _bulletDamage;
        [SerializeField] private float _bulletSpeed;
        
        public BulletController BulletController => _bulletController;

        public float BulletDamage => _bulletDamage;
        
        public float BulletSpeed => _bulletSpeed;
    }
}