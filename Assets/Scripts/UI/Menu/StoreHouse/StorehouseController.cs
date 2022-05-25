using System.Collections.Generic;
using Bottle;
using UnityEngine;

namespace UI.Menu {

    public class StorehouseController : MonoBehaviour {

        [SerializeField] private StorehouseView _storehouseView;
        [SerializeField] private BottleTypesStorage _typesStorage;
        
        private StorehouseModel _storehouseModel;
        private Dictionary<BottleItem, BottleType> _controllerTypes;
        private List<BottleItem> _bottleItems;
        
        private void Start() {
            _controllerTypes = new Dictionary<BottleItem, BottleType>();
            _storehouseModel = new StorehouseModel();
            _bottleItems = new List<BottleItem>();

            if (_storehouseModel.HasBottles) {
                GenerateBottleAmountsList();
            }
            
            _storehouseView.SetWarningBoxVisability(!_storehouseModel.HasBottles);
            
            _storehouseView.SellAllBottles += SellAllBottlesButtonClick;
            _storehouseModel.NoMoreBottles += OnNoMoreBottles;
            
        }

        private void OnNoMoreBottles() {
            _storehouseView.SetWarningBoxVisability(true);
        }

        private void GenerateBottleAmountsList() {
            foreach (var bottleType in _typesStorage.BottleTypes) {
                int amount = _storehouseModel.TryGetAmount(bottleType.BottleType);
                if (amount == -1) continue;
                
                BottleItem item = _storehouseView.ApendBottleElementView();
                item.Initialize(bottleType.BottleName, bottleType.BottlePrice.ToString(), amount.ToString());
                item.SetIcon(bottleType.BottleIcon);

                item.OnSold += OnSellBottle;
                
                _bottleItems.Add(item);
                _controllerTypes.Add(item, bottleType.BottleType);
            }
        }

        private void OnSellBottle(BottleItem item) {
            _storehouseModel.RevomeBottle(_controllerTypes[item]);
            _controllerTypes.Remove(item);
            Walet.GetInstance().Coins += (item.Anount * item.Price);

            item.OnSold -= OnSellBottle;
            _storehouseView.MakeSellSound();
            _bottleItems.Remove(item);
            
            Destroy(item.gameObject);
        }

         private void SellAllBottlesButtonClick() {
             foreach (var item in _bottleItems) {
                 Walet.GetInstance().Coins += (item.Anount * item.Price);
                 _storehouseModel.RevomeBottle(_controllerTypes[item]);
                 Destroy(item.gameObject);            
                 item.OnSold -= OnSellBottle;
                 _controllerTypes.Remove(item);
             }
             
             _storehouseView.SetWarningBoxVisability(true);
         }
         
        private void OnDestroy() {
            if (_bottleItems.Count > 0) {
                foreach (var item in _bottleItems) { 
                    item.OnSold -= OnSellBottle;
                }
            }
            _storehouseView.SellAllBottles -= SellAllBottlesButtonClick;
            _storehouseModel.SaveModel();
        }

        private void OnApplicationPause(bool pauseStatus) {
           if (pauseStatus) {
               _storehouseModel.SaveModel();
           }
        }
        
    }
    
}