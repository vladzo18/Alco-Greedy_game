using System.Collections;
using UnityEngine;

public class CameraMover : MonoBehaviour {

    [SerializeField] private Vector3 _mainPosition;
    [SerializeField] private Vector3 _shopPosition;
    [SerializeField] private Vector3 _storehousePosition;
    [SerializeField, Range(0.1f, 1f)] private float _moveingTime = 0.5f;

    public void MoveToMain() {
        StartCoroutine(MoveCorutine(_mainPosition, _moveingTime));
    }
    
    public void MoveToShop() {
        StartCoroutine(MoveCorutine(_shopPosition, _moveingTime));
    }
    
    public void MoveToStorehouse() {
        StartCoroutine(MoveCorutine(_storehousePosition, _moveingTime));
    }
    
    private IEnumerator MoveCorutine(Vector3 targetPosition, float time) {
        
        Vector3 startPosition = this.transform.position;
        float elapsedTime = 0;

        while (elapsedTime <= time) {
            this.transform.position = Vector3.Lerp(startPosition, targetPosition, elapsedTime / time);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        this.transform.position = targetPosition;
    }
    
}
