using System.Collections.Generic;
using UnityEngine;

namespace Game {

    public class GameComplexity : MonoBehaviour {
        
        [SerializeField] private AnimationCurve _complexityCurve;

        private const float CURVE_STEP = 0.1f;
        private float _currentCurvePossition;

        private List<IComplexityHandler> _complexityHandlers = new List<IComplexityHandler>();
        
        public void Register(IComplexityHandler complexityHandler) {
            _complexityHandlers.Add(complexityHandler);
        }
        
        public void UnRegister(IComplexityHandler complexityHandler) {
            _complexityHandlers.Remove(complexityHandler);
        }
        
        public void MoveInComplexity() {
            _currentCurvePossition += CURVE_STEP;
            foreach (var handler in _complexityHandlers) {
                handler.SetComplexity(_complexityCurve.Evaluate(_currentCurvePossition));
            }
        }
        
    }
}