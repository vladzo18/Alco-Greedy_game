using System;
using Bottle;
using Game;
using UnityEngine;

public class BottleCatcher : MonoBehaviour {
    
    public event Action<BottleType> OnBottleHit;

    [SerializeField] private Animator _animator;
    [SerializeField] private string _catcheAnimationKey;

    private void OnCollisionEnter2D(Collision2D other) {
        Bottle.Bottle bottleOfVodka = other.collider.GetComponent<Bottle.Bottle>();
        
        if (bottleOfVodka != null && bottleOfVodka.GetState() != BottleState.Droped) {
            GameSound.Instance.PlayOnCatchBottleSound();
            _animator.SetTrigger(_catcheAnimationKey);
            OnBottleHit?.Invoke(bottleOfVodka.CurrentBottleTypeDescriptor.BottleType);
            bottleOfVodka.CatchBottle();
        }
    }
    
}
