using System;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public event Action Taked;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.TryGetComponent<Movement>(out Movement player))
        {
            Taked?.Invoke();
            Destroy(gameObject);
        }
    }
}
