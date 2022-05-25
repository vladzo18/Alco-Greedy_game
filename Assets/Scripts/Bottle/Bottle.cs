using System;
using ObjectPool;
using UI.Game;
using UnityEngine;

namespace Bottle {
    
    public class Bottle : MonoBehaviour, IPoolable, IPauseHandler {
        
        [SerializeField] private ParticleSystem _brokenGlassParticleSystem;
        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] private BottleTypesStorage _bottleTypesStorage;

        [SerializeField] private Rigidbody2D _rigidbody2D;
        
        private BottleState _currentState;
        private BottleTypeDescriptor _currentBottleTypeDescriptor;
        private Vector2 _pausedPosition;

        public Transform Transform => this.transform;
        public event Action<GameObject> OnReturnToPool;

        public BottleTypeDescriptor CurrentBottleTypeDescriptor => _currentBottleTypeDescriptor;

        private void Start() {
            _currentState = BottleState.Falling;
            _currentBottleTypeDescriptor = _bottleTypesStorage.GetRandomButtleType();
            _spriteRenderer.sprite = _currentBottleTypeDescriptor.BottleIcon;
            
            PauseManager.Instance.Register(this);
        }

        private void OnDestroy() {
            PauseManager.Instance.UnRegister(this);
        }

        public BottleState GetState() => _currentState;

        public void BreakBottle() {
            _currentState = BottleState.Droped;
            _spriteRenderer.enabled = false;
            _brokenGlassParticleSystem.Play();
            Invoke(nameof(ReturnToPool), _brokenGlassParticleSystem.main.duration);
        }

        public void CatchBottle() {
            ReturnToPool();
        }
        
        public void ReturnToPool() {
            _currentState = BottleState.Falling;
            _currentBottleTypeDescriptor = _bottleTypesStorage.GetRandomButtleType();
            _spriteRenderer.sprite = _currentBottleTypeDescriptor.BottleIcon;
            _spriteRenderer.enabled = true;
            OnReturnToPool?.Invoke(gameObject);
        }
        
        private void Update() {
            if (PauseManager.Instance.IsPaused) {
                _rigidbody2D.position = _pausedPosition;
                _rigidbody2D.velocity = Vector2.zero;
            } 
        }

        public void SetPaused(bool isPaused) {
            if (isPaused) {
                _pausedPosition = _rigidbody2D.position;
            }
        }
        
    }
    
}