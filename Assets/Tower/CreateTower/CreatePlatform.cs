using UnityEngine;

namespace CreateTower
{
    public class CreatePlatform : MonoBehaviour
    {
        [SerializeField] private TowerFactory towerFactory;
        public void CreateTower(TowersTypes.TowerTypes type)
        {
            Vector3 position = transform.position;
            towerFactory.Create(type, new Vector3(position.x, position.y + 5, position.z));
        }
    }
}
