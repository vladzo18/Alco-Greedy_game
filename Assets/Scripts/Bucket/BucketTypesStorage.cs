using System.Collections.Generic;
using UnityEngine;

namespace Bucket {
    
    [CreateAssetMenu(fileName = "BucketTypes", menuName = "Storage/BucketTypesStorage")]
    public class BucketTypesStorage : ScriptableObject {

        [SerializeField] private List<BucketTypeDescriptor> _bucketTypes;
        
        public List<BucketTypeDescriptor> BucketTypes => _bucketTypes;

    }
    
}