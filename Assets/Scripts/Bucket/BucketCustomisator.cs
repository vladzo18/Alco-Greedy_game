using System;
using UnityEngine;

namespace Bucket {
    
    public class BucketCustomisator : MonoBehaviour {

        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] private BucketTypesStorage _bucketTypesStorage;

        private void Start() {
            BucketType bucketType = (BucketType)Enum.Parse(typeof(BucketType), PlayerPrefs.GetString("bucketSkin"));
            Sprite sprite = _bucketTypesStorage.BucketTypes.Find(b => b.Type.Equals(bucketType)).Image;
            _spriteRenderer.sprite = sprite;
        }
        
    }
    
}