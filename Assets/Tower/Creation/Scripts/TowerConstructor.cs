using System.Collections;
using UI.Scripts;
using UnityEngine;

namespace Creation.Scripts
{
    public class TowerConstructor : MonoBehaviour
    {
        [SerializeField] private PlatformRaycaster platformRaycaster;
        [SerializeField] private TowerTypeManager _towerTypeManager;
        [SerializeField] private TowerFactory _towerFactory;
        [SerializeField] private TowerSeller _towerSeller;
        [SerializeField] private AlertUI alertUI;
        [SerializeField] private float _delayBeforeNextConstruction;
        
        private TowersTypes.TowerTypes _type; 
        
        private bool _isCreatePool;
        private bool _delayCreation;
        
        private void Update()
        {
            if (_delayCreation == false && Input.GetMouseButton(0)) PrepareToConstruct();
        }
        
        private void PrepareToConstruct()
        {
            _delayCreation = true;
            PlatformConstructor platformConstructor = platformRaycaster.GetCreatePlatform();
            
            StartCoroutine(DelayBeforeNextConstruction(_delayBeforeNextConstruction));
            
            if (platformConstructor == null) return;
            
            _towerTypeManager.ChooseTypeTower();
                
            if (_towerTypeManager.Type != 0) ConstructTower(_towerTypeManager.Type,platformConstructor);
        }
        
        private void ConstructTower(TowersTypes.TowerTypes type, PlatformConstructor platformConstructor)
        {
            if (_towerSeller.PurchasingCheck(_towerSeller.GetPriceTower(type)))
            {
                Vector3 position = platformConstructor.transform.position;
                
                ReservePlace(type, platformConstructor);
                _towerFactory.Create(type, new Vector3(position.x, position.y + 5, position.z));
            }
            else alertUI.FadeUIAnimation.AnimationPlay(alertUI.SetText("У вас недостаточно монет для покупки"));
        }

        private void ReservePlace(TowersTypes.TowerTypes type, PlatformConstructor platformConstructor)
        {
            platformConstructor.TakePlace();
            platformConstructor.SetTowerType(type);
        }
        
        private IEnumerator DelayBeforeNextConstruction(float delay)
        {
            yield return new WaitForSeconds(delay);
            _delayCreation = false;
        }
    }
}
