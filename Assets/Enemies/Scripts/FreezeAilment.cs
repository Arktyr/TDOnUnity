using System.Collections;
using UnityEngine;

namespace Enemies.Scripts
{
    public class FreezeAilment : MonoBehaviour
    {
        public void FreezeEnemy(EnemyBase currentEnemyBase, float freezePower, float freezeDuration)
        {
            if (currentEnemyBase.CheckMinimumSpeed()) return;
            
            currentEnemyBase.SetSpeed(SetSlowdown(currentEnemyBase, freezePower));
            StartCoroutine(FreezeDuration(currentEnemyBase, freezeDuration, freezePower));
        }

        private float SetSlowdown(EnemyBase currentEnemyBase, float freezePower) => currentEnemyBase.Speed - freezePower;

        private float SetBoost(EnemyBase currentEnemyBase, float freezePower) => currentEnemyBase.Speed + freezePower;

        private IEnumerator FreezeDuration(EnemyBase currentEnemyBase, float freezeDuration, float freezePower)
        {
            yield return new WaitForSeconds(freezeDuration);

            if (currentEnemyBase.gameObject == null) yield break;
            
            currentEnemyBase.SetSpeed(SetBoost(currentEnemyBase, freezePower));
        }
    }
}