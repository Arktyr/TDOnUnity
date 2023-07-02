using UnityEngine;

namespace UI.Scripts
{
    public class UIRaycast : MonoBehaviour
    {
        [SerializeField] private Camera _mainCamera;
        
        private RaycastHit _hit;
        private Ray _ray;
        
        public RaycastHit Hit => _hit;
        public Ray Ray => _ray;
        
        private void FixedUpdate()
        {
            _ray = _mainCamera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(_ray, out _hit, Mathf.Infinity))
            {

            }
        }
    }
}