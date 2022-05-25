using System;
using System.Collections.Generic;
using Game;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour {
    
    [SerializeField] private List<Image> _images;
    
    public event Action EmptyHealth;
    
    public void DecreaseHealth() {
        for (int i = _images.Count - 1; i >= 0; i--) {
            if (_images[i].enabled) {
                _images[i].enabled = false;
                if (i == 0) {
                    EmptyHealth?.Invoke();
                }
                break;
            }
        }
    }

    public void RestoreHealth() {
        foreach (var item in _images) {
            item.enabled = true;
        }

    }

}
