using System;
using System.Collections;
using UI.Scripts;
using UnityEngine;

namespace CreateTower
{
    public class CreateTower : MonoBehaviour
    {
        [SerializeField] private Camera mainCamera;
        [SerializeField] private SetTowerType setTowerType;
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
                CreateTowerOnHit(_ray, _layerMask);
            }
        }
        
        private void CreateTowerOnHit(Ray ray, int layerMask)
        {
            if (CheckCollisionHit(ray, layerMask).collider == null) return;
            if (CheckCollisionHit(ray, layerMask).collider.TryGetComponent(out CreatePlatform createPlatform) &&
                _delayCreation == false && Input.GetMouseButton(0))
            {
                _delayCreation = true;
                setTowerType.ChooseTypeTower();
                if (setTowerType.Type != 0)
                {
                    createPlatform.CreateTower(setTowerType.Type);
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
    }
}
