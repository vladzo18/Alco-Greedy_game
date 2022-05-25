using System;
using Game;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Menu {

    public class StorehouseView : MonoBehaviour {

        [Header("General View Elements")]
        [SerializeField] private Transform _containerTransform;
        [SerializeField] private Button _backToMenuButton;
        [SerializeField] private Button _toSkinShopButton;
        [SerializeField] private Button _sellAllButton;
        [SerializeField] private GameObject _warningBox;
        [Header("Other")]
        [SerializeField] private BottleItem bottleItemPrefab;
        [SerializeField] private CameraMover _cameraMover;
        
        public event Action SellAllBottles;
        
        private void Start() {
            _backToMenuButton.onClick.AddListener(OnBackToMenu);
            _toSkinShopButton.onClick.AddListener(OnToSkinShop);
            _sellAllButton.onClick.AddListener(OnSellAll);
            _sellAllButton.gameObject.SetActive(false);
        }

        private void OnDestroy() {
            _backToMenuButton.onClick.RemoveListener(OnBackToMenu);
            _toSkinShopButton.onClick.RemoveListener(OnToSkinShop);
            _sellAllButton.onClick.RemoveListener(OnSellAll);
        }

        public void SetWarningBoxVisability(bool isVisible) {
            _warningBox.SetActive(isVisible);
            _sellAllButton.gameObject.SetActive(!isVisible);
        }

        public BottleItem ApendBottleElementView() {
            BottleItem item = Instantiate(bottleItemPrefab, _containerTransform);
            _sellAllButton.gameObject.SetActive(true);
            return item;
        }
        
        public void MakeSellSound() => GameSound.Instance.PlayOnSellSound();

        private void OnBackToMenu() {
            GameSound.Instance.PlayOnClickSound();
            _cameraMover.MoveToMain();
        }

        private void OnToSkinShop() {
            GameSound.Instance.PlayOnClickSound();
            _cameraMover.MoveToShop();
        }

        private void OnSellAll() {
            GameSound.Instance.PlayOnSellSound();
            SellAllBottles?.Invoke();
            _sellAllButton.gameObject.SetActive(false);
        }
        
    }

}

