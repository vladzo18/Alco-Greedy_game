using UnityEngine.SceneManagement;

namespace Game {

    public static class SceneLoader {

        public static void LoadPreventScene() {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }

        public static void LoadNextScene() {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

    }

}
