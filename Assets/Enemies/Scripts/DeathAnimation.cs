using DG.Tweening;
using UnityEngine;

namespace Enemies.Scripts
{
    public class DeathAnimation : MonoBehaviour
    {
        [SerializeField] private float _scaleDuration;
       
        private float _scaleEndValue;

        public float ScaleDuration => _scaleDuration;

        public void PlayAnimation(Enemy enemy, float scaleEndValue)
        {
            enemy.transform.DOScale(scaleEndValue, _scaleDuration)
                .SetLink(enemy.gameObject)
                .SetEase(Ease.InQuart)
                .Play();
        }
    }
}