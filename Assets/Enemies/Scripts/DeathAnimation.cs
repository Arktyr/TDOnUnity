using DG.Tweening;
using UnityEngine;

namespace Enemies.Scripts
{
    public class DeathAnimation : MonoBehaviour
    {
        [SerializeField] private float _scaleDuration;
        
        public float ScaleDuration => _scaleDuration;

        public void PlayAnimation(EnemyBase enemyBase, float scaleEndValue)
        {
            Transform enemyTransform = enemyBase.transform;

            enemyTransform.DOScale(scaleEndValue, _scaleDuration).SetEase(Ease.InQuart).Play();

        }
    }
}