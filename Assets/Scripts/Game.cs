using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace PlatformerMVC
{
    public class Game : MonoBehaviour
    {
        [SerializeField] private InteractiveObjectView _playerView;
        [SerializeField] private CannonView _cannonView;
        [SerializeField] private AIConfig _config;
        [SerializeField] private EnemyView _enemyView;
        [SerializeField] private GeneratorLevelView _generatorView;

        private PlayerController _playerController;
        private CannonController _cannonController;
        private EmiterController _emiterController;
        private SimplePatrolAI _simplePatrolAI;
        private GeneratorController _generatorController;
        private CameraController _cameraController;

        private void Awake()
        {
            _playerController = new PlayerController(_playerView);
            _cannonController = new CannonController(_cannonView._muzzleT, _playerView.transform);
            _emiterController = new EmiterController(_cannonView._bullets, _cannonView._emitterT);
            //_simplePatrolAI = new SimplePatrolAI(_enemyView, new SimplePatrolAIModel(_config));
            _cameraController = new CameraController(_playerView, Camera.main.transform);
            _generatorController = new GeneratorController(_generatorView);

            _generatorController.Start();
        }

        void Update()
        {
            _playerController.Update();
            _cannonController.Update();
            _emiterController.Update();
            _cameraController.Update();
        }

        private void FixedUpdate()
        {
            //_simplePatrolAI.FixedUpdate();
        }
    }
}