using System;
using System.Collections;
using Palmmedia.ReportGenerator.Core.Reporting.Builders;
using UI.Scripts;
using UnityEngine;

namespace CreateTower
{
    public class CreateTower : MonoBehaviour
    {
        [SerializeField] private Camera mainCamera;
        [SerializeField] private SetTowerType setTowerType;
        [SerializeField] private TowerFactory towerFactory;
        [SerializeField] private Alert alert;
        [SerializeField] private MoneyCounter moneyCounter;
        private Ray _ray;
        private RaycastHit _hit;
        private MeshRenderer _lastMeshRenderer;
        private CreatePlatform _createPlatform;
        private TowersTypes.TowerTypes _type;
        private MeshRenderer _platformMeshRenderer;
        private int _layerMask;
        private bool _delayCreation;

        private void Update()
        {
            if (_delayCreation == false)
            {
                GetPositionUserClick();
            }
        }

        private void GetPositionUserClick()
        {
            _ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            _layerMask = 1 << LayerMask.NameToLayer("Ignore Raycast");
            if (Input.GetMouseButton(0) && _delayCreation == false)
            {
                CheckForConstruct(_ray, _layerMask);
            }
        }
        
        private void CheckForConstruct(Ray ray, int layerMask)
        {
            if (CheckCollisionHit(ray, layerMask).collider == null) return;
            if (CheckCollisionHit(ray, layerMask).collider.TryGetComponent(out CreatePlatform createPlatform) &&
                _delayCreation == false && Input.GetMouseButton(0))
            {
                _delayCreation = true;
                setTowerType.ChooseTypeTower();
                if (createPlatform.isEmpty)
                {
                    ChangePlatformColor(_lastMeshRenderer, Color.red);
                    StartCoroutine(alert.AnimationPlay("Здесь уже установлена вышка"));
                }
                if (setTowerType.Type != 0 && createPlatform.isEmpty == false)
                {
                    ConstructTower(setTowerType.Type, createPlatform);
                }
                StartCoroutine(DelayBeforeNextConstruction());
            }
        }

        private RaycastHit CheckCollisionHit(Ray ray, int layerMask )
        {
            if (Physics.Raycast(ray, out _hit, Mathf.Infinity, ~layerMask) && Input.GetMouseButton(0))
            {
                if (_hit.collider.TryGetComponent(out CreatePlatform createPlatform))
                {
                    CheckLastMeshRenderer(createPlatform);
                    return _hit;
                }
            }
            if (_lastMeshRenderer != null)
            {
                ChangePlatformColor(_lastMeshRenderer, Color.white);
            }
            return _hit;
        }

        private void CheckLastMeshRenderer(CreatePlatform createPlatform)
        {
            if (createPlatform != null)
            {
                _platformMeshRenderer = createPlatform.GetComponent<MeshRenderer>();
                if (_lastMeshRenderer != null)
                {
                    ChangePlatformColor(_lastMeshRenderer, Color.white);
                }
                _lastMeshRenderer = _platformMeshRenderer;
                ChangePlatformColor(_platformMeshRenderer,Color.green);
            }
        }
        
        private void ChangePlatformColor(MeshRenderer platform, Color color)
        {
            platform.material.color = color;
        }
        
        private IEnumerator DelayBeforeNextConstruction()
        {
            yield return new WaitForSeconds(1);
            _delayCreation = false;
        }
        
        private void ConstructTower(TowersTypes.TowerTypes type, CreatePlatform createPlatform)
        {
            if (moneyCounter.Money >= towerFactory.GetPriceTower(type))
            {
                TakePlace(type, createPlatform);
                moneyCounter.BuyTower(towerFactory.GetPriceTower(type));
                Vector3 position = createPlatform.transform.position;
                towerFactory.Create(type, new Vector3(position.x, position.y + 5, position.z));
            }
            else
            {
                StartCoroutine(alert.AnimationPlay("У вас недостаточно монет для покупки"));
            }
        }

        private void TakePlace(TowersTypes.TowerTypes type, CreatePlatform createPlatform)
        {
            createPlatform.isEmpty = true;
            createPlatform.type = type;
        }
    }
}
