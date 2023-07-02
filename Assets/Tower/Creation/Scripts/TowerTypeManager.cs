using UnityEngine;

namespace Creation.Scripts
{
    public class TowerTypeManager : MonoBehaviour
    {
        [SerializeField] private InteractionUI _interactionUI;
        
        private TowersTypes.TowerTypes _type;
        
        public TowersTypes.TowerTypes Type => _type;
        
        public void ChooseTypeTower()
        {
            _type = 0;
            if (_interactionUI.LaserEnable) ChooseTypeLaserTower();
            
            if (_interactionUI.BulletEnable) ChooseTypeBulletTower();
            
            if (_interactionUI.FreezeEnable) ChooseTypeFreezeTower();
            
            if (_interactionUI.AOEEnable) ChooseTypeAOETower();
            
            if (_interactionUI.DamageUpEnable) ChooseTypeDamageUpTower();
            
            if (_interactionUI.RateOfFireUpEnable) ChooseTypeRateOfFireUpTower();
        }
        
        private void ChooseTypeLaserTower() => _type = TowersTypes.TowerTypes.LaserTower;

        private void ChooseTypeBulletTower() => _type = TowersTypes.TowerTypes.BulletTower;

        private void ChooseTypeFreezeTower() => _type = TowersTypes.TowerTypes.FreezeTower;
        
        private void ChooseTypeAOETower() => _type = TowersTypes.TowerTypes.AOETower;
        
        private void ChooseTypeDamageUpTower() => _type = TowersTypes.TowerTypes.DamageUpTower;
        
        private void ChooseTypeRateOfFireUpTower() => _type = TowersTypes.TowerTypes.RateOfFireUpTower;
    }
}