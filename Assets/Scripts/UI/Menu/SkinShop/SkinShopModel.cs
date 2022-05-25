using System;
using System.Collections.Generic;
using Bucket;
using Other;
using Serialization;
using UnityEngine;

namespace UI.Menu {
    
    public class SkinShopModel {
        
        private List<BucketType> _availableBuckets;
        
        public bool HasAvaliableBuckets => _availableBuckets.Count > 0;
        public BucketType CurrentBucket { get; set; }
        
        public SkinShopModel(BucketType defaultBucket) {
            _availableBuckets = _availableBuckets = Serializator.DeserializeData<List<BucketType>>(StringLiterals.SavePathToAvaliableBuckets);
            _availableBuckets ??= new List<BucketType>();
            
            string savedBucketType = PlayerPrefs.GetString(StringLiterals.CurrentBucketSkinTypeSaveKey);
               
            if (string.IsNullOrEmpty(savedBucketType)) {
                CurrentBucket = defaultBucket;
                _availableBuckets.Add(CurrentBucket);
            } else {
                CurrentBucket = (BucketType) Enum.Parse(typeof(BucketType), savedBucketType);
            }
        }

        public void SaveModel() {
            Serializator.SerializeData(_availableBuckets, StringLiterals.SavePathToAvaliableBuckets); 
            PlayerPrefs.SetString(StringLiterals.CurrentBucketSkinTypeSaveKey, CurrentBucket.ToString());
        }

        public bool IsAvaliableBucket(BucketType bucketType) {
            return _availableBuckets.Contains(bucketType);
        }

        public void AddBucket(BucketType bucketType) {
            _availableBuckets.Add(bucketType);
        }
        
    }
    
}