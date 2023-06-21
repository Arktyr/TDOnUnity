using UnityEngine;

namespace Creation.Scripts
{
    public class PlatformColorController : MonoBehaviour
    {
        private MeshRenderer _lastMeshRenderer;

        public void CheckLastMeshRenderer(MeshRenderer createPlatformMeshRenderer)
        {
            if (_lastMeshRenderer != null) ChangePlatformColor(_lastMeshRenderer, Color.white);
            
            if (createPlatformMeshRenderer != null)
            {
                SetLastMeshRenderer(createPlatformMeshRenderer);
                ChangePlatformColor(createPlatformMeshRenderer, Color.green);
            }
        }
        
        public void ChangePlatformColor(MeshRenderer platform, Color color) => platform.material.color = color;

        private void SetLastMeshRenderer(MeshRenderer createPlatformMeshRenderer) =>
            _lastMeshRenderer = createPlatformMeshRenderer;
    }
}