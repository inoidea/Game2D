using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace PlatformerMVC
{
    public class Game : MonoBehaviour
    {
        [SerializeField] private LevelObjectView _playerView;
        [SerializeField] private CannonView _cannonView;

        private PlayerController _playerController;
        private CannonController _cannonController;

        private void Awake()
        {
            _playerController = new PlayerController(_playerView);
            _cannonController = new CannonController(_cannonView._muzzleT, _playerView.transform);
        }

        void Update()
        {
            _playerController.Update();
            _cannonController.Update();
        }
    }
}