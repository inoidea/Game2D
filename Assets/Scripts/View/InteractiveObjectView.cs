using System;
using System.Collections.Generic;
using UnityEngine;

namespace PlatformerMVC
{
    public class InteractiveObjectView : LevelObjectView
    {
        public Action<BulletView> TakeDamage { get; set; }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out BulletView contractView))
            {
                TakeDamage?.Invoke(contractView);
            }
        }
    }
}
