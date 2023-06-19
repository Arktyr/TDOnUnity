using DG.Tweening;
using UnityEngine;

namespace Enemies.Scripts
{
    public class DeathAnimation : MonoBehaviour
    {
        [SerializeField] private float _scaleEndValue;
        [SerializeField] private float _scaleDuration;

        public float ScaleDuration => _scaleDuration;

        public void PlayAnimation(GameObject enemyGameObject)
        {
            enemyGameObject.transform.DOScale(_scaleEndValue, _scaleDuration)
                .SetLink(enemyGameObject)
                .SetEase(Ease.InQuart)
                .Play();
        }
    }
}