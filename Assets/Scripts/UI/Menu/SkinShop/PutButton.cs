using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Menu {
    
    public class PutButton : MonoBehaviour {

        [SerializeField] private Button _button;
        [SerializeField] private Image _putImage;
        [SerializeField] private Image _putedImage;

        private bool _isPuted;
        
        public event Action OnPut;

        public void SetPutStatus(bool isPuted) {
            if (isPuted) {
                MakePut();
            } else {
                MakeDisput();
            }
            _isPuted = isPuted;
        }
        
        private void Start() {
            _button.onClick.AddListener(OnPutHandler);
        }

        private void OnDestroy() {
            _button.onClick.RemoveListener(OnPutHandler);
        }

        private void MakePut() {
            _button.image = _putedImage;
            _putedImage.gameObject.SetActive(true);
            _putImage.gameObject.SetActive(false);
        }
        
        private void MakeDisput() {
            _button.image = _putImage;
            _putedImage.gameObject.SetActive(false);
            _putImage.gameObject.SetActive(true);
        }
        
        private void OnPutHandler() {
            if (_isPuted) {
                return;
            }
            OnPut.Invoke();
            MakePut();
            _isPuted = true;
        }
        
    }
    
}