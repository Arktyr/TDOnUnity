using DG.Tweening;
using UnityEngine;

namespace Enemy
{
    public class DeathAnimation : MonoBehaviour
    {
        private Sequence _sequence;
        private Transform _enemyTransform;
        private GameObject _enemyGameObject;
        
        public void PlayAnimation(Transform enemyTransform,GameObject enemyGameObject)
        {
            _sequence = DOTween.Sequence();
            _enemyTransform = enemyTransform;
            _sequence.Append(_enemyTransform.DOScale(0, 0.5f).SetLink(enemyGameObject).SetEase(Ease.InQuart)).Play();
        }
    }
}