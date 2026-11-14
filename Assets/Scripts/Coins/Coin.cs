using UnityEngine;

// Монета: обертається і при дотику гравця додає себе в гаманець.
public class Coin : MonoBehaviour
{
    [SerializeField] private CoinWallet wallet;
    [SerializeField] private float rotateSpeed = 180f;

    private bool collected;

    private void Awake()
    {
        if (wallet == null) wallet = FindFirstObjectByType<CoinWallet>();
    }

    private void Update()
    {
        transform.Rotate(0f, rotateSpeed * Time.deltaTime, 0f, Space.World);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (collected || !other.CompareTag("Player")) return;
        collected = true;
        wallet.AddCoin();
        Destroy(gameObject);
    }
}
