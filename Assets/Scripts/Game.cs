using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace PlatformerMVC
{
    public class Game : MonoBehaviour
    {
        [SerializeField] private LevelObjectView _playerView;
        private PlayerController _playerController;

        private void Awake()
        {
            _playerController = new PlayerController(_playerView);
        }

        void Update()
        {
            _playerController.Update();
        }
    }
}