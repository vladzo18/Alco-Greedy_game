using UnityEngine;

namespace Other {
    
    [RequireComponent(typeof(RectTransform))]
    public class SafeArea : MonoBehaviour {

        private RectTransform _rectTransform;
        
        private void Awake() {
            _rectTransform = GetComponent<RectTransform>();
            
            UpdateSafeArea();
        }

        private void Update() {
            UpdateSafeArea();
        }

        private void UpdateSafeArea() {
            var safeArea = Screen.safeArea;
            
            var anchorMin = safeArea.position;
            var anchorMax = safeArea.position + safeArea.size;

            anchorMin.x /= Screen.width;
            anchorMin.y /= Screen.height;
            anchorMax.x /= Screen.width;
            anchorMax.y /= Screen.height;

            _rectTransform.anchorMin = anchorMin;
            _rectTransform.anchorMax = anchorMax;
        }
        
    }
    
}