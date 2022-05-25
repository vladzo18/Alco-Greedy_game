using System.Collections.Generic;
using Bucket;
using UnityEngine;

namespace UI.Menu {
    
    public class SkinShopController : MonoBehaviour {

        [SerializeField] private SkinShopView _skinShopView;
        [SerializeField] private BucketTypesStorage _typesStorage;
        
        private List<BucketItem> _bucketItems;
        private SkinShopModel _skinShopModel;
        
        private Dictionary<BucketItem, BucketType> _bucketTypes;
        
        private void Start() {
            _bucketItems = new List<BucketItem>();
            _skinShopModel = new SkinShopModel(_typesStorage.BucketTypes[0].Type);
            _bucketTypes = new Dictionary<BucketItem, BucketType>();
            
            GenerateBucketElementsList();
        }

        private void GenerateBucketElementsList() {
            foreach (var type in _typesStorage.BucketTypes) {
                BucketItem item = _skinShopView.AppendBucketElementView();
                item.Initialize(type.Name, type.Price.ToString(), type.Image);
                
                item.OnBuy += OnBucketBuyButtonClick;
                item.OnPut += OnBucketPutButtonClick;
                
                if (_skinShopModel.IsAvaliableBucket(type.Type)) {
                    item.PriceBoxVasability(false);
                }

                if (type.Type.Equals(_skinShopModel.CurrentBucket)) {
                    item.SetStatus(true);
                }
                
                _bucketTypes.Add(item, type.Type);
                _bucketItems.Add(item);
            }
        }

        private void OnBucketPutButtonClick(BucketItem item) {
            _skinShopView.PlayPutSound();
            
            foreach (var controller in _bucketItems) {
                controller.SetStatus(false);
            }
            item.SetStatus(true);
            
            _skinShopModel.SaveModel();
            _skinShopModel.CurrentBucket = _bucketTypes[item];
        }
        
        private void OnBucketBuyButtonClick(BucketItem item) {
            if (Walet.GetInstance().Coins >= item.Price) {
                _skinShopView.PlayBuySound();
                Walet.GetInstance().Coins -= item.Price;
                item.PriceBoxVasability(false);
                _skinShopModel.AddBucket(_bucketTypes[item]);
            } else {
                _skinShopView.PlayCantBuySound();
            }
        }
        
        private void OnDestroy() {
            foreach (var item in _bucketItems) {
                item.OnBuy -= OnBucketBuyButtonClick;
                item.OnPut -= OnBucketPutButtonClick;
            }
            
            if (_skinShopModel.HasAvaliableBuckets) _skinShopModel.SaveModel();
        }

        private void OnApplicationPause(bool pauseStatus) {
            if (pauseStatus && _skinShopModel.HasAvaliableBuckets) _skinShopModel.SaveModel();
        }
        
    }
    
}