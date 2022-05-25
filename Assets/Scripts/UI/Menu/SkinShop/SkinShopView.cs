using Game;
using UI.Menu;
using UnityEngine;
using UnityEngine.UI;

public class SkinShopView : MonoBehaviour {
    
    [Header("General View Elements")]
    [SerializeField] private Transform _containerTransform;
    [SerializeField] private Button _backToMenuButton;
    [SerializeField] private Button _toStorehouseButton;
    [Header("Other")]
    [SerializeField] private BucketItem bucketItemPrefab;
    [SerializeField] private CameraMover _cameraMover;

    private void Start() {
        _backToMenuButton.onClick.AddListener(OnBackToMenu);
        _toStorehouseButton.onClick.AddListener(OnToStorehouse);
    }
    
    public void PlayPutSound() => GameSound.Instance.PlayOnClickSound();
    public void PlayBuySound() => GameSound.Instance.PlayOnBuySound();
    public void PlayCantBuySound() => GameSound.Instance.PlayOnLockSwipeSound();

    public BucketItem AppendBucketElementView() {
        BucketItem item = Instantiate(bucketItemPrefab, _containerTransform);
        //...
        return item;
    }
    
    private void OnBackToMenu() {
         GameSound.Instance.PlayOnClickSound();
         _cameraMover.MoveToMain();
    }

    private void OnToStorehouse() {
        GameSound.Instance.PlayOnClickSound();
        _cameraMover.MoveToStorehouse();
    }
    
}
