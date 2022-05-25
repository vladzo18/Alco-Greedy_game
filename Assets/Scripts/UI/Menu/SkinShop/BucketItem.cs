using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Menu {
    
    public class BucketItem : MonoBehaviour {
        
        [SerializeField] private Image _bucketIcon;
        [SerializeField] private Text _bucketName;
        [SerializeField] private Text _bucketPrice;
        [SerializeField] private Button _buyButton;
        [SerializeField] private PutButton _putButton;
        [SerializeField] private GameObject _priceBox;

        public event Action<BucketItem> OnBuy;
        public event Action<BucketItem> OnPut;
        
        public int Price => Int32.Parse(_bucketPrice.text);
        
        public void Initialize(string name, string prise, Sprite image) {
            _bucketName.text = name;
            _bucketPrice.text = prise;
            _bucketIcon.sprite = image;
        }

        public void PriceBoxVasability(bool isVisible) {
            _priceBox.gameObject.SetActive(isVisible);
            _buyButton.gameObject.SetActive(isVisible);
            _putButton.gameObject.SetActive(!isVisible);
        }

        public void SetStatus(bool isPuted) {
            _putButton.SetPutStatus(isPuted);
        }
        
        private void Start() {
            _buyButton.onClick.AddListener(Buy);
            _putButton.OnPut += Put;
        }
        
        private void OnDestroy() {
            _buyButton.onClick.RemoveListener(Buy);
            _putButton.OnPut -= Put;
        }
        
        private void Buy() => OnBuy.Invoke(this);
        private void Put() => OnPut.Invoke(this);

    }
    
}