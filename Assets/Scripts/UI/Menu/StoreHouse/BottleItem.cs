using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Menu {
    
    public class BottleItem : MonoBehaviour {

        [SerializeField] private Image _icon;
        [SerializeField] private Text _name;
        [SerializeField] private Text _amount;
        [SerializeField] private Text _price;
        [SerializeField] private Button _sellButton;
        
        public event Action<BottleItem> OnSold;

        public int Anount => Int32.Parse(_amount.text);
        public int Price => Int32.Parse(_price.text);
        
        public void SetAmount(string text) => _amount.text = text;
        public void SetIcon(Sprite sprite) => _icon.sprite = sprite;
        
        public void Initialize(string name, string price, string amount) { 
            _name.text = name;
            _price.text = price;
            _amount.text = amount;
        }

        private void Start() {
            _sellButton.onClick.AddListener(OnSell);
        }

        private void OnDestroy() {
            _sellButton.onClick.RemoveListener(OnSell);
        }
        
        private void OnSell() => OnSold?.Invoke(this);
        
    }
}