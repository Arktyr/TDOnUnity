using System;
using UnityEngine;
using UnityEngine.Events;

namespace Events
{
    public class WaveEvent
    {

        public static Action<int> OnEnemySpawn;
        
        
        public static void SendEnemySpawn(int remainingCount)
        {
            OnEnemySpawn.Invoke(remainingCount);
        }

    }
}
