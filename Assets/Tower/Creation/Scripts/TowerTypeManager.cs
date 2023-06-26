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
        }
        
        private void ChooseTypeLaserTower() => _type = TowersTypes.TowerTypes.LaserTower;

        private void ChooseTypeFreezeTower() => _type = TowersTypes.TowerTypes.FreezeTower;

        private void ChooseTypeBulletTower() => _type = TowersTypes.TowerTypes.BulletTower;
    }
}