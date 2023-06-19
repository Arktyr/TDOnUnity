using Implementations.Laser.Scripts;
using UnityEngine;

namespace Configs.Scripts
{
 [CreateAssetMenu ( fileName = "LaserTowerConfig", menuName = "Configs/LaserTowerConfig")]
 public class LaserTowerConfig : ScriptableObject
 {
  [SerializeField] private LaserTower _tower;
  [SerializeField] private float _laserTowerDamage;
  [SerializeField] private float _priceLaserTower;
  
  public LaserTower Tower => _tower;
  
  public float LaserTowerDamage => _laserTowerDamage;
  
  public float PriceLaserTower => _priceLaserTower;
 }
}
