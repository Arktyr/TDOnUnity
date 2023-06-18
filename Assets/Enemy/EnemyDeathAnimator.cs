using DG.Tweening;
using UnityEngine;

namespace Enemy
{
    public class EnemyDeathAnimator : MonoBehaviour
    {
        public readonly float ScaleDuration = 0.5f;
        private const int ScaleEndValue = 0;

        private Sequence _sequence;
        
        public void PlayScaleAnimation(GameObject enemyGameObject)
        {
            Transform enemyTransform = enemyGameObject.transform;
            
            _sequence = DOTween.Sequence();

            _sequence.Append(enemyTransform
                .DOScale(ScaleEndValue, ScaleDuration)
                .SetLink(enemyGameObject)
                .SetEase(Ease.InQuart));
                
            _sequence.Play();
        }
    }
}