using Implementations.Freeze.Scripts;
using UnityEngine;

namespace Configs.Scripts
{
    [CreateAssetMenu(fileName = "FreezeTowerConfig", menuName = "Configs/FreezeTower")]
    public class FreezeTowerConfig : ScriptableObject
    {
        [SerializeField] private FreezeTower tower;
        [SerializeField] private float freezeTowerDamage;
        [SerializeField] private float freezingPower;
        [SerializeField] private float priceFreezeTower;
        public FreezeTower Tower => tower;
        public float FreezingPower => freezingPower;
        public float FreezeTowerDamage => freezeTowerDamage;
        public float PriceFreezeTower => priceFreezeTower;
    }
}
