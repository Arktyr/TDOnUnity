﻿using UnityEngine;
using Bullet_Tower;

namespace Configs
{
    [CreateAssetMenu(fileName = "BulletControllerConfig", menuName = "Configs/BulletControllerConfig")]
    public class BulletControllerConfig : ScriptableObject
    {
        [SerializeField] private BulletController bulletcontroller;
        public BulletController BulletController => bulletcontroller;
    }
}