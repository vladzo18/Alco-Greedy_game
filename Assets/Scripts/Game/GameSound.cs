using UnityEngine;

namespace Game {

    [RequireComponent(typeof(AudioSource))]
    public class GameSound : MonoBehaviour {

        private static GameSound _instance;
        public static GameSound Instance => _instance;
        
        private AudioSource _audioSource;

        [SerializeField] private AudioClip _OnClickSound;
        [SerializeField] private AudioClip _OnSwipeSound;
        [SerializeField] private AudioClip _OnLockSwipeSound;
        [SerializeField] private AudioClip _OnCatchBottleSound;
        [SerializeField] private AudioClip _OnBottleBreake;
        [SerializeField] private AudioClip _OnBuySound;
        [SerializeField] private AudioClip _OnSellSound;

        private void Start() {
            _audioSource = GetComponent<AudioSource>();
            _audioSource.playOnAwake = false;
            
            if (Instance == null) {
                _instance = this;
                DontDestroyOnLoad(this);
            }
        }

        public void PlayOnClickSound() => _audioSource.PlayOneShot(_OnClickSound);
        public void PlayOnSwipeSound() => _audioSource.PlayOneShot(_OnSwipeSound);
        public void PlayOnLockSwipeSound() => _audioSource.PlayOneShot(_OnLockSwipeSound);
        public void PlayOnCatchBottleSound() => _audioSource.PlayOneShot(_OnCatchBottleSound);
        public void PlayOnBottleBreake() => _audioSource.PlayOneShot(_OnBottleBreake);
        public void PlayOnBuySound() => _audioSource.PlayOneShot(_OnBuySound);
        public void PlayOnSellSound() => _audioSource.PlayOneShot( _OnSellSound);

    }

}
