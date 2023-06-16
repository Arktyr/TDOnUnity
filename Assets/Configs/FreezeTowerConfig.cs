using Freeze_Tower;
using UnityEngine;

namespace Configs
{
    [CreateAssetMenu(fileName = "FreezeTowerConfig", menuName = "Configs/FreezeTower")]
    public class FreezeTowerConfig : ScriptableObject
    {
        [SerializeField] private FreezeTower tower;
        [SerializeField] private float freezeTowerDamage;
        [SerializeField] private float freezingPower;
        public FreezeTower Tower => tower;
        public float FreezingPower => freezingPower;
        public float FreezeTowerDamage => freezeTowerDamage;
    }
}