using Implementations.BaseTowerLogic;
using UnityEngine;

namespace Configs.Scripts
{
    [CreateAssetMenu(fileName = "BulletControllerConfig", menuName = "Configs/BulletControllerConfig")]
    public class BulletControllerConfig : ScriptableObject
    {
        [SerializeField] private BulletBase bulletBase;
        [SerializeField] private float _bulletSpeed;
        [SerializeField] private float _delayBeforeDestroy;
        
        public BulletBase BulletBase => bulletBase;
        
        public float BulletSpeed => _bulletSpeed;

        public float DelayBeforeDestroy => _delayBeforeDestroy;
    }
}