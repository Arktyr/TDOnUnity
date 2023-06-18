using Implementations.Laser;
using UnityEngine;

namespace Configs
{
 [CreateAssetMenu ( fileName = "LaserTowerConfig", menuName = "Configs/LaserTowerConfig")]
 public class LaserTowerConfig : ScriptableObject
 {
  [SerializeField] private LaserTower tower;
  [SerializeField] private float laserTowerDamage;
  [SerializeField] private float priceLaserTower;
  
  public LaserTower Tower => tower;
  public float LaserTowerDamage => laserTowerDamage;
  public float PriceLaserTower => priceLaserTower;
 }
}
