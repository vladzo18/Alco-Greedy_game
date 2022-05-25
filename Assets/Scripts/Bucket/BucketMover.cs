using System;
using Bucket;
using Game;
using UnityEngine;

public class BucketMover : MonoBehaviour {
    
        [SerializeField] private int _moveDictanse;
        [SerializeField] private float _movementSpeed;
        [Header("Animations")]
        [SerializeField] private Animator _animator;
        [SerializeField] private string _leftBlockAnimationKey;
        [SerializeField] private string _rightBlockAnimationKey;

        private WorldPosition _currentWorldPosition;
        private bool _canMove;
        private Vector3 _targetLerpPosition;
        
        private Vector3 _defaultPosition;
        private float _defaultMovementSpeed;
        
        public float MovementSpeed {
            get => _movementSpeed; 
            set => _movementSpeed = value;
        }

        private void Start() {
            _currentWorldPosition = WorldPosition.Center;
            _defaultPosition = transform.position;
            _defaultMovementSpeed = _movementSpeed;
            _targetLerpPosition = new Vector3(0, 0, 0);

            GameOverManager.Instance.GameRestart += MoveToDefaultPosition;
        }

        private void OnDestroy() {
            GameOverManager.Instance.GameRestart -= MoveToDefaultPosition;
        }

        private void Update() {
            if (_canMove) {
                transform.position = Vector3.Lerp(transform.position, _targetLerpPosition, Time.deltaTime * _movementSpeed);
                if (transform.position.x == _targetLerpPosition.x) {
                    _canMove = false;
                }
            } 
        }
        
        public void MoveRight() {
            if (_currentWorldPosition != WorldPosition.Right) {
                int targetPositionX = Mathf.RoundToInt(transform.position.x) + _moveDictanse;
                _targetLerpPosition.Set(targetPositionX, _defaultPosition.y, _defaultPosition.z);

                _currentWorldPosition += 1;
                _canMove = true;
                
                GameSound.Instance.PlayOnSwipeSound();
            } else {
                GameSound.Instance.PlayOnLockSwipeSound();
                _animator.SetTrigger(_rightBlockAnimationKey);
            }
        }
    
        public void MoveLeft() {
            if (_currentWorldPosition != WorldPosition.Left) {
                int targetPositionX = Mathf.RoundToInt(transform.position.x) - _moveDictanse;
                _targetLerpPosition.Set(targetPositionX, _defaultPosition.y, _defaultPosition.z);

                _currentWorldPosition -= 1;
                _canMove = true;
                
                GameSound.Instance.PlayOnSwipeSound();
            } else {
                GameSound.Instance.PlayOnLockSwipeSound();
                _animator.SetTrigger(_leftBlockAnimationKey);
            }
        }

        public void MoveToDefaultPosition() {
            MovementSpeed = _defaultMovementSpeed;
            _canMove = true;
            _currentWorldPosition = WorldPosition.Center;
            _targetLerpPosition = _defaultPosition;
        }
        
}
