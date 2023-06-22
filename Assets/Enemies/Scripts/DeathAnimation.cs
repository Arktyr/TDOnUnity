using DG.Tweening;
using UnityEngine;

namespace Enemies.Scripts
{
    public class DeathAnimation : MonoBehaviour
    {
        [SerializeField] private float _scaleDuration;
        
        public float ScaleDuration => _scaleDuration;

        public void PlayAnimation(Enemy enemy, float scaleEndValue)
        {
            Transform enemyTransform = enemy.transform;

            enemyTransform.DOScale(scaleEndValue, _scaleDuration).SetEase(Ease.InQuart).Play();

        }
    }
}