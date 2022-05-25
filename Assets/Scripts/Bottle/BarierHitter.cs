using System;
using Bottle;
using Game;
using UnityEngine;

namespace Other {
    
    public class BarierHitter : MonoBehaviour {
        
        public event Action BottleHit;
        
        private void OnCollisionEnter2D(Collision2D other) {
            Bottle.Bottle bottleOfVodka = other.collider.GetComponent<Bottle.Bottle>();
            
            if (bottleOfVodka != null && bottleOfVodka.GetState() == BottleState.Falling) {
                GameSound.Instance.PlayOnBottleBreake();
                bottleOfVodka.BreakBottle();
                BottleHit?.Invoke();
            }
        }

    }

}
