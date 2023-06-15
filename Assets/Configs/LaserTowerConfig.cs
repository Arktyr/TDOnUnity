using Laser_Tower;
using UnityEngine;

namespace Configs
{
 [CreateAssetMenu ( fileName = "LaserTowerConfig", menuName = "Configs/LaserTowerConfig")]
 public class LaserTowerConfig : ScriptableObject
 {
  [SerializeField] private LaserTower tower;
  [SerializeField] private float laserTowerDamage;
  public LaserTower Tower => tower;
  public float LaserTowerDamage => laserTowerDamage;
 }
}
