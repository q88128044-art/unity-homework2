using UnityEngine;

// Двері-слухач: відкриваються, коли зібрано потрібну кількість монет.
// Усі двері підписуються на ту саму подію CoinWallet.CoinsChanged.
public class Door : MonoBehaviour
{
    [SerializeField] private CoinWallet wallet;
    [SerializeField] private int requiredCoins = 5;
    [SerializeField] private float openDepth = 3.2f;
    [SerializeField] private float openSpeed = 2f;

    private bool isOpen;
    private Vector3 openPosition;

    private void Awake()
    {
        if (wallet == null) wallet = FindFirstObjectByType<CoinWallet>();
        openPosition = transform.position + Vector3.down * openDepth;
    }

    private void OnEnable() => wallet.CoinsChanged += OnCoinsChanged;
    private void OnDisable() => wallet.CoinsChanged -= OnCoinsChanged;

    private void OnCoinsChanged(int coins)
    {
        if (isOpen || coins < requiredCoins) return;
        isOpen = true;
        Debug.Log($"{name}: відкрито ({requiredCoins} монет)");
    }

    private void Update()
    {
        if (isOpen)
            transform.position = Vector3.MoveTowards(transform.position, openPosition, openSpeed * Time.deltaTime);
    }
}
