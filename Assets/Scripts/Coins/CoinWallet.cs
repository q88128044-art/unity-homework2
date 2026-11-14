using System;
using UnityEngine;

// Гаманець монет: зберігає кількість і повідомляє слухачів через подію.
public class CoinWallet : MonoBehaviour
{
    [SerializeField] private int totalCoins = 10;

    public int Coins { get; private set; }
    public int TotalCoins => totalCoins;

    // Подія: передає поточну кількість зібраних монет.
    public event Action<int> CoinsChanged;

    public void AddCoin()
    {
        Coins++;
        Debug.Log($"Зібрано: {Coins} / {totalCoins}");
        CoinsChanged?.Invoke(Coins);
    }
}
