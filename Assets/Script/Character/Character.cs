using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

namespace StarterAssets
{
#if ENABLE_INPUT_SYSTEM
    [RequireComponent(typeof(PlayerInput))]
#endif
    public class Character : MonoBehaviour
    {
        private CharacterInputSystem _input;
        private Rigidbody _rigidbody;
#if ENABLE_INPUT_SYSTEM
        private PlayerInput _playerinput;
#endif
        private Animator _animator;
        Camera _mainCamera;
        public Vector2 input;

        public int P_Hp;
        public float MoveSpeed = 2f; // 기본속도
        public float SprintSpeed = 5.3f; // 뛰는속도

        //public float 





        public float targetSpeed=1f;
        private float _speed;
        private float _animationBlend;
        private float _targetRotation = 0.0f;
        private float _rotationVelocity;
        private float _verticalVelocity;
        private float _terminalVelocity = 53.0f;
        public float SpeedChangeRate = 10.0f;
        public float RotationSmoothTime = 0.12f;
        private bool _hasAnimator;

        public int _animIDSpeed;
        public int _animIDMotionSpeed;

        public class Vector2Event : UnityEvent<Vector2> { }

        public Vector2Event onLookEvent;
        private bool isCurrentDeviceMouse
        {
            get
            {
                return _playerinput.currentControlScheme == "PC";
            }
        }

        void Start()
        {
            _input = GetComponent<CharacterInputSystem>();
            _playerinput = GetComponent<PlayerInput>();

            //_animator = GetComponentInChildren<Animator>();
            _hasAnimator = TryGetComponent(out _animator);
            _rigidbody = GetComponent<Rigidbody>();
            _mainCamera = Camera.main;

            Cursor.lockState = CursorLockMode.Locked;
        }

        // Update is called once per frame
        void Update()
        {
            Move();
        }


        private void LateUpdate()
        {
            //CameraRotation();
        }


        private void AssignAnimationIds()
        {
            _animIDSpeed = Animator.StringToHash("Speed");
            _animIDMotionSpeed = Animator.StringToHash("MotionSpeed");
        }

        private void Move()
        {
            float targetSpeed = _input.sprint ? SprintSpeed : MoveSpeed;

            if (_input.move == Vector2.zero)
            {
                targetSpeed = 0.0f;
            }
            float currentHorizontalSpeed = _rigidbody.velocity.magnitude;
            float speedOffset = 0.1f;
            float inputMagnitude = _input.analogMovement ? _input.move.magnitude : 1f;

            if (currentHorizontalSpeed < targetSpeed - speedOffset || currentHorizontalSpeed > targetSpeed + speedOffset)
            {
                _speed = Mathf.Round(_speed * 1000f) / 100f;
            }
            else
            {
                _speed = targetSpeed;
            }

            _animationBlend = Mathf.Lerp(_animationBlend, targetSpeed, Time.deltaTime * SpeedChangeRate);
            if (_animationBlend < 0.01f)
            {
                _animationBlend = 0f;
            }
            Vector3 inputDirection = new Vector3(_input.move.x, 0.0f, _input.move.y).normalized;

            if (_input.move != Vector2.zero)
            {
                _targetRotation = Mathf.Atan2(inputDirection.x, inputDirection.z) * Mathf.Rad2Deg +
                                  _mainCamera.transform.eulerAngles.y;
                float rotation = Mathf.SmoothDampAngle(transform.eulerAngles.y, _targetRotation, ref _rotationVelocity,RotationSmoothTime);

                // rotate to face input direction relative to camera position
                transform.rotation = Quaternion.Euler(0.0f, rotation, 0.0f);
            }

            Vector3 targetDirection = Quaternion.Euler(0.0f, _targetRotation, 0.0f) * Vector3.forward;

            // move the player
            _rigidbody.velocity = targetDirection.normalized * (_speed) + new Vector3(0.0f, _verticalVelocity, 0.0f);

            // update animator if using character
            if (_hasAnimator)
            {
                _animator.SetFloat(_animIDSpeed, _animationBlend);
                //_animator.SetFloat(_animIDMotionSpeed, inputMagnitude);
            }

        }
    }
}