using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace PlatformerMVC
{
    public class Game : MonoBehaviour
    {
        [SerializeField] private LevelObjectView _playerView;
        private AnimationConfig _config;
        private SpriteAnimController _playerAnimator;

        private float speed = 10f;

        private void Awake()
        {
            _config = Resources.Load<AnimationConfig>("SpriteAnimCfg");
            _playerAnimator = new SpriteAnimController(_config);
            _playerAnimator.StartAnimation(_playerView._spriteRenderer, AnimState.Run, true, speed);
        }

        void Update()
        {
            _playerAnimator.Update();
        }
    }
}