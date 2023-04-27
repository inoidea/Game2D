using Unity.VisualScripting.FullSerializer;
using UnityEngine;

namespace PlatformerMVC
{
    public class PlayerController
    {
        private AnimationConfig _config;
        private SpriteAnimController _playerAnimator;
        private ContactPooler _contactPooler;
        private LevelObjectView _playerView;

        private Transform _playerT;
        private Rigidbody2D _rb;

        private float _walkSpeed = 150f;
        private float _animSpeed = 10f;
        private float _movingTreshold = 0.1f;
        private float _jumpForce = 7f;
        private float _jumpTreshold = 1f;
        private bool _isJump;
        private bool _isMoving;

        private Vector3 _leftScale = new Vector3(-1, 1, 1);
        private Vector3 _rightScale = new Vector3(1, 1, 1);

        private float _yVelocity = 0;
        private float _xVelocity = 0;
        private float _xAxisInput;

        public PlayerController(LevelObjectView player) {
            _playerView = player;
            _playerT = player._transform;
            _rb = player._rb;

            _config = Resources.Load<AnimationConfig>("SpriteAnimCfg");
            _playerAnimator = new SpriteAnimController(_config);
            _playerAnimator.StartAnimation(player._spriteRenderer, AnimState.Run, true, _animSpeed);
            _contactPooler = new ContactPooler(_playerView._collider);
        }

        private void MoveTowards() {
            _xVelocity = Time.fixedDeltaTime * _walkSpeed * (_xAxisInput < 0  ? -1 : 1);
            _rb.velocity = new Vector2(_xVelocity, _yVelocity);
            _playerT.localScale = _xAxisInput < 0 ? _leftScale : _rightScale;
        }

        public void Update()
        {
            _playerAnimator.Update();
            _contactPooler.Update();
            _xAxisInput = Input.GetAxis("Horizontal");
            _isJump = Input.GetAxis("Vertical") > 0;
            _yVelocity = _rb.velocity.y;
            _isMoving = Mathf.Abs(_xAxisInput) > _movingTreshold;

            _playerAnimator.StartAnimation(_playerView._spriteRenderer, _isMoving ? AnimState.Run : AnimState.Idel, true, _animSpeed);

            if (_isMoving)
            {
                MoveTowards();
            }
            else
            {
                _xVelocity = 0;
                _rb.velocity = new Vector2(_xVelocity, _rb.velocity.y);
            }

            if (_contactPooler.IsGrounded)
            {
                if (_isJump && _yVelocity <= _jumpTreshold)
                {
                    _rb.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
                }
            }
            else if ((_contactPooler.RightContact || _contactPooler.LeftContact) && !_contactPooler.IsGrounded) {
                _xVelocity = 0;
                _rb.velocity = new Vector2(_xVelocity, _rb.velocity.y);
            }
            else
            {
                if (Mathf.Abs(_yVelocity) > _jumpTreshold)
                {
                    _playerAnimator.StartAnimation(_playerView._spriteRenderer, AnimState.Jump, true, _animSpeed);
                }
            }
        }
    }
}
