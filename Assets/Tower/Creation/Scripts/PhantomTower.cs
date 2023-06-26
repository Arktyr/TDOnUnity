using Implementations.BaseTower;
using UnityEngine;

namespace Creation.Scripts
{
    public class PhantomTower : MonoBehaviour
    {
        [SerializeField] private PlatformRaycaster _platformRaycaster;
        [SerializeField] private InteractionUI _interactionUI;
        [SerializeField] private TowerFactory _towerFactory;

        private GameObject _bulletTower;
        private GameObject _freezeTower;
        private GameObject _laserTower;

        private bool _interactionEnable;

        private void Start() => PreparePhantomTower();

        private void Update() => SetTransformPhantomTower(CheckInteractionUI());

        private void PreparePhantomTower()
        {
            Transform parent = transform.parent;

            _bulletTower = CreatePhantomTower(_towerFactory.BulletTowerConfig.Tower.gameObject, parent);

            _freezeTower = CreatePhantomTower(_towerFactory.FreezeTowerConfig.Tower.gameObject, parent);

            _laserTower = CreatePhantomTower(_towerFactory.LaserTowerConfig.Tower.gameObject, parent);
        }

        private GameObject CreatePhantomTower(GameObject towerCreate, Transform parent)
        {
            GameObject tower = Instantiate(towerCreate, parent);
            Destroy(tower.GetComponent<BaseTower>());
            tower.gameObject.SetActive(false);
            return tower;
        }
        
        private GameObject CheckInteractionUI()
        {
            if (_interactionUI.BulletEnable)
            {
                SetStatePhantomTower(_bulletTower, true);
                SetInteraction(true);
                return _bulletTower;
            }
            
            if (_interactionUI.FreezeEnable)
            {
                SetStatePhantomTower(_freezeTower, true);
                SetInteraction(true);
                return _freezeTower;
            }
            
            if (_interactionUI.LaserEnable)
            {
                SetStatePhantomTower(_laserTower, true);
                SetInteraction(true);
                return _laserTower;
            }
            
            SetInteraction(false);
            
            if (_interactionEnable == false) ResetPhantomTowers();

            return null;
        }

        private void SetInteraction(bool state) => _interactionEnable = state;
        
        private void ResetPhantomTowers()
        {
            if (_bulletTower.gameObject.activeSelf) SetStatePhantomTower(_bulletTower, false);
            
            if (_freezeTower.gameObject.activeSelf) SetStatePhantomTower(_freezeTower, false);
                
            if (_laserTower.gameObject.activeSelf)  SetStatePhantomTower(_laserTower, false);
        }
        
        private void SetStatePhantomTower(GameObject baseTower, bool state) => baseTower.gameObject.SetActive(state);

        private void SetTransformPhantomTower(GameObject baseTower)
        {
            if (baseTower == null) return;

            baseTower.transform.position = _platformRaycaster.Hit.point;
        }
    }
}