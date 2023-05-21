using System;
using UnityEngine;

namespace PlatformerMVC
{
    [Serializable]
    public struct AIConfig
    {
        public float Speed;
        public float MinDistToTarget;
        public Transform[] Waypoints;
    }
}
