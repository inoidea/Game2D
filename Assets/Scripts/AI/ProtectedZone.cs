using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace PlatformerMVC
{
    public class ProtectedZone
    {
        private List<IProtector> _protectors;
        private LevelObjectTrigger _view;

        public ProtectedZone(LevelObjectTrigger view, List<IProtector> protectors) {
            _protectors = protectors;
            _view = view;
        }

        public void Init() {
            _view.TriggerEnter += OnContact;
            _view.TriggerEnter += OnExit;
        }

        public void DeInit()
        {
            _view.TriggerEnter -= OnContact;
            _view.TriggerEnter -= OnExit;
        }

        private void OnContact(GameObject player)
        {
            foreach (var protector in _protectors)
                protector.StartProtection(player);
        }

        private void OnExit(GameObject player)
        {
            foreach (var protector in _protectors)
                protector.FinishProtection(player);
        }
    }
}
