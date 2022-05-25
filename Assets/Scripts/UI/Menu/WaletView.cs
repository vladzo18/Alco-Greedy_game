using UnityEngine;
using UnityEngine.UI;

namespace UI.Menu {
    
    public class WaletView : MonoBehaviour {

        [SerializeField] private Text _waletText;

        private void Start() {
            _waletText.text = Walet.GetInstance().Coins.ToString();
        }

        private void Update() {
            _waletText.text = Walet.GetInstance().Coins.ToString();
        }

        private void OnDestroy() {
            Walet.GetInstance().SaveState();
        }

        private void OnApplicationPause(bool pauseStatus) {
            Walet.GetInstance().SaveState();
        }
        
    }
    
}