using UnityEngine;


namespace Other {

    [RequireComponent(typeof(Camera))]
    public class CameraConstantToWidth : MonoBehaviour {

        [SerializeField] private Vector2Int _targetWidthAndHeight = new Vector2Int(1280, 720);

        private Camera _camera;

        private void Start() {
            _camera = GetComponent<Camera>();
            fitCameraSize();
        }

        private void fitCameraSize() {
            float targetAspect = (float) _targetWidthAndHeight.y / _targetWidthAndHeight.x;
            if (_camera.aspect != targetAspect) {
                float cameraSize = _camera.aspect + targetAspect;
                _camera.orthographicSize += cameraSize;
                transform.position = new Vector3(transform.position.x, transform.position.y + cameraSize,
                    transform.position.z);
            }
        }

    }

}
