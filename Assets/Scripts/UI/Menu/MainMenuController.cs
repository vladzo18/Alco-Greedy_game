using Game;
using UnityEngine;

namespace UI.Menu {
    
    public class MainMenuController : MonoBehaviour {
        
        [SerializeField] private MainMenuView _mainMenuView;
        
        private void Start() {
            _mainMenuView.OnPlay += onPlayButtonClick;
        }

        private void OnDestroy() {
            _mainMenuView.OnPlay -= onPlayButtonClick;
        }

        private void onPlayButtonClick() {
            Invoke(nameof(ToGameScene), 0.25f);
        }
        
        private void ToGameScene() => SceneLoader.LoadNextScene();
        
    }
    
}