using UnityEngine;
using Bullet_Tower;

namespace Configs
{
    [CreateAssetMenu(fileName = "BulletControllerConfig", menuName = "Configs/BulletControllerConfig")]
    public class BulletControllerConfig : ScriptableObject
    {
        [SerializeField] private BulletController bulletController;
        [SerializeField] private float bulletSpeed;

        public BulletController BulletController => bulletController;
        public float BulletSpeed => bulletSpeed;
    }
}