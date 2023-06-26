using Implementations.Freeze_Tower.Scripts;
using UnityEngine;

namespace Configs.Scripts
{
    [CreateAssetMenu(fileName = "FreezeTowerConfig", menuName = "Configs/FreezeTower")]
    public class FreezeTowerConfig : ScriptableObject
    {
        [SerializeField] private FreezeTower _tower;
        [SerializeField] private float _freezeTowerDamage;
        [SerializeField] private float _freezingPercents;
        [SerializeField] private float _freezeDuration;
        [SerializeField] private float _priceFreezeTower;
        
        public FreezeTower Tower => _tower;
        
        public float FreezingPercents => _freezingPercents;
        
        public float FreezeTowerDamage => _freezeTowerDamage;

        public float FreezeDuration => _freezeDuration;
        
        public float PriceFreezeTower => _priceFreezeTower;
    }
}
