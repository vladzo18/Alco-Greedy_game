using System;
using Game;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuView : MonoBehaviour {

    [Header("General View Elements")]
    [SerializeField] private Button _playButton;
    [SerializeField] private Button _shopButton;
    [SerializeField] private Button _storehauseButton;
    [Header("Other")]
    [SerializeField] private CameraMover _cameraMover;
    [SerializeField] private Animator _playButtonAnimator;

    public event Action OnPlay;
    
    private void Start() {
        _playButton.onClick.AddListener(Play);
        _shopButton.onClick.AddListener(MoveToShop);
        _storehauseButton.onClick.AddListener(MoveToStorehouse);
    }

    private void OnDestroy() {
        _playButton.onClick.RemoveListener(Play);
        _shopButton.onClick.RemoveListener(MoveToShop);
        _storehauseButton.onClick.RemoveListener(MoveToStorehouse);
    }

    private void Play() {
        OnPlay?.Invoke();
        GameSound.Instance.PlayOnClickSound();
        _playButtonAnimator.SetTrigger("Press");
    }

    private void MoveToShop() {
        GameSound.Instance.PlayOnClickSound();
        _cameraMover.MoveToShop();
    }

    private void MoveToStorehouse() {
        GameSound.Instance.PlayOnClickSound();
        _cameraMover.MoveToStorehouse();
    }
    
}
