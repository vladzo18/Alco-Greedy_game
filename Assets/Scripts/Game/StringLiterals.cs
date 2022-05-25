using System.IO;
using UnityEngine;

namespace Other {
    
    public static class StringLiterals {
        
        public static string SavePathToAvaliableBuckets => Path.Combine(Application.persistentDataPath, "availableBuckets.json");
        public static string SavePathToBottlesAmount => Path.Combine(Application.persistentDataPath, "bottlesAmount.json");
        public static string CurrentBucketSkinTypeSaveKey = "bucketSkin";
        public static string WaletSaveKey = "walet";

    }
    
}