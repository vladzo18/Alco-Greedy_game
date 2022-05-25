using System.Collections.Generic;
using UnityEngine;

namespace Bottle {
    
    [CreateAssetMenu(fileName = "BottleTypes", menuName = "Storage/BottleTypesStorage")]
    public class BottleTypesStorage : ScriptableObject {

        [SerializeField] private List<BottleTypeDescriptor> _bottleTypes;
        
        public List<BottleTypeDescriptor> BottleTypes => _bottleTypes;

        private int GetMassSums() {
            int _massSum = 0;
            
            foreach (var type in _bottleTypes) {
                _massSum += type.BottleMass;
            }

            return _massSum;
        }

        public BottleTypeDescriptor GetRandomButtleType() {
            int index = Random.Range(0, GetMassSums());
            int sum = 0;
            
            if (index == 0) {
                return _bottleTypes[0];
            } else if (index == GetMassSums()) {
                return _bottleTypes[_bottleTypes.Count - 1];
            }

            return _bottleTypes.Find((b) => {
                sum += b.BottleMass;
                if (index <= sum) {
                    return true;
                }
                return false;
            });
        }

    }
    
}