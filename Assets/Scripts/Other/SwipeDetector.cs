using System;
using UnityEngine;

namespace Other {

    public class SwipeDetector : MonoBehaviour {

        [SerializeField] private int _swipeLenght;

        private Vector2 _startPosition;
        private Vector2 _deltaPosition;
        
        public event Action RightSwipe;
        public event Action LeftSwipe;

        private void Update() {
            if (Input.touchCount > 0) {
                Touch touch = Input.GetTouch(0);

                if (touch.phase == TouchPhase.Began) {
                    _startPosition = touch.position;
                }

                if (touch.phase == TouchPhase.Ended && _startPosition.x != 0) {
                    _deltaPosition = touch.position - _startPosition;

                    if (Mathf.Abs(_deltaPosition.x) > _swipeLenght) {
                        if (_deltaPosition.x > 0) {
                            RightSwipe?.Invoke();
                        } else if (_deltaPosition.x < 0) {
                            LeftSwipe?.Invoke();
                        }
                    }
                }
            }
        }
        
    }

}