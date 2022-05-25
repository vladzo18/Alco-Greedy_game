using Other;
using UnityEngine;

namespace UI.Menu {
    
    public class Walet {
        
        private static Walet _instance;
        
        public static Walet GetInstance() {
            if (_instance == null) _instance = new Walet();
            return _instance;
        }
        
        private Walet() {
            Coins = PlayerPrefs.GetInt(StringLiterals.WaletSaveKey, Coins);
        }
        
        public int Coins { get; set; }

        public void SaveState() {
            PlayerPrefs.SetInt(StringLiterals.WaletSaveKey, Coins);
        }
        
    }

}