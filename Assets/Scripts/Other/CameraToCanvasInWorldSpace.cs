using UnityEngine;

namespace Other {

    [RequireComponent(typeof(Camera))]
    public class CameraToCanvasInWorldSpace : MonoBehaviour {

        [SerializeField] private Vector2Int _targetWidthAndHeight = new Vector2Int(1280, 720);

        private Camera _camera;

        private void Start() {
            _camera = this.GetComponent<Camera>();
            
            float targetAspect = (float) _targetWidthAndHeight.y / _targetWidthAndHeight.x;
            float size = (_camera.orthographicSize * targetAspect) / _camera.aspect;
            _camera.orthographicSize = size;
        }
    }

}