using System;
using System.Collections.Generic;
using Bottle;
using Other;
using Serialization;

namespace UI.Menu {
    
    public class StorehouseModel {

        private Dictionary<BottleType, int> BottlesAmount;

        public bool HasBottles => BottlesAmount.Count > 0;
        
        public event Action NoMoreBottles;
        
        public StorehouseModel() {
            BottlesAmount = Serializator.DeserializeData<Dictionary<BottleType, int>>(StringLiterals.SavePathToBottlesAmount);
            BottlesAmount ??= new Dictionary<BottleType, int>();
        }

        public void SaveModel() {
            Serializator.SerializeData(BottlesAmount, StringLiterals.SavePathToBottlesAmount);
        }

        public void RevomeBottle(BottleType bottleType) {
            BottlesAmount.Remove(bottleType);
            if (!HasBottles) NoMoreBottles.Invoke();
        }

        public void AddBottle(BottleType bottleType, int amount) {
            BottlesAmount.Add(bottleType, amount);
        }

        public int TryGetAmount(BottleType bottleType) {
            if (BottlesAmount.TryGetValue(bottleType, out int amount)) {
                return amount;
            }
            return -1;
        }
        
    }
    
}