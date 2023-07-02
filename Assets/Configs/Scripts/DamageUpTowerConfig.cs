using Implementations.PowerUpTowers.DamageUpTower.Scripts;
using UnityEngine;

namespace Configs.Scripts
{
    [CreateAssetMenu(fileName = "DamageUpTowerConfig", menuName = "Configs/DamageUpTower")]
    public class DamageUpTowerConfig : ScriptableObject
    {
        [SerializeField] private DamageUpTower _damageUpTower;
        [SerializeField] private float _percentsUpDamage;
        [SerializeField] private float _price;

        public DamageUpTower DamageUpTower => _damageUpTower;
        public float PercentsUpDamage => _percentsUpDamage;

        public float Price => _price;
    }
}