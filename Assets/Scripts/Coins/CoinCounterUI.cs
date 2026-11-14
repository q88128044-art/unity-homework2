using UnityEngine;
using UnityEngine.UI;

// Слухач події: оновлює текст "Зібрано: X / 10".
public class CoinCounterUI : MonoBehaviour
{
    [SerializeField] private CoinWallet wallet;
    [SerializeField] private Text label;

    private void Awake()
    {
        if (label == null) label = GetComponent<Text>();
        if (wallet == null) wallet = FindFirstObjectByType<CoinWallet>();
    }

    private void OnEnable() => wallet.CoinsChanged += Refresh;
    private void OnDisable() => wallet.CoinsChanged -= Refresh;

    private void Start() => Refresh(wallet.Coins);

    private void Refresh(int coins)
    {
        label.text = $"Зібрано: {coins} / {wallet.TotalCoins}";
    }
}
