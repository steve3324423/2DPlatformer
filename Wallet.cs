using System;
using UnityEngine;

public class Wallet : MonoBehaviour
{
    [SerializeField] private Coin[] _coins;

    private int _count = 0;

    public event Action<int> ChangedCountCoin;

    private void OnEnable()
    {
        foreach (Coin coin in _coins)
            coin.Taked += OnTaked;
    }

    private void OnDestroy()
    {
        foreach (Coin coin in _coins)
            coin.Taked -= OnTaked;
    }

    private void OnTaked()
    {
        _count++;
        ChangedCountCoin?.Invoke(_count);
    }
}
