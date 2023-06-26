using System.Collections;
using UnityEngine;

namespace Enemies.Scripts
{
    public class FreezeAilment : MonoBehaviour
    {
        public void FreezeEnemy(Enemy currentEnemy, float freezePower, float freezeDuration)
        {
            if (currentEnemy.CheckMinimumSpeed()) return;
            
            currentEnemy.SetSpeed(SetSlowdown(currentEnemy, freezePower));
            StartCoroutine(FreezeDuration(currentEnemy, freezeDuration, freezePower));
        }

        private float SetSlowdown(Enemy currentEnemy, float freezePower) => currentEnemy._speed - freezePower;

        private float SetBoost(Enemy currentEnemy, float freezePower) => currentEnemy._speed + freezePower;

        private IEnumerator FreezeDuration(Enemy currentEnemy, float freezeDuration, float freezePower)
        {
            yield return new WaitForSeconds(freezeDuration);

            if (currentEnemy.gameObject == null) yield break;
            
            currentEnemy.SetSpeed(SetBoost(currentEnemy, freezePower));
        }
    }
}