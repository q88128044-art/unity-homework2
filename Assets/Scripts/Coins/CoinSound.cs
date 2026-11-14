using UnityEngine;

// Новий слухач події CoinWallet.CoinsChanged: грає короткий звук після кожної монети.
// Код CoinWallet не змінюється — CoinSound просто підписується на подію.
[RequireComponent(typeof(AudioSource))]
public class CoinSound : MonoBehaviour
{
    [SerializeField] private CoinWallet wallet;
    [SerializeField] private AudioClip clip; // можна підставити свій звук; якщо порожньо — генерується
    [SerializeField, Range(0f, 1f)] private float volume = 0.6f;

    private AudioSource source;

    private void Awake()
    {
        source = GetComponent<AudioSource>();
        source.playOnAwake = false;
        source.spatialBlend = 0f;
        if (wallet == null) wallet = FindFirstObjectByType<CoinWallet>();
        if (clip == null) clip = CreateCoinClip();
    }

    private void OnEnable() => wallet.CoinsChanged += OnCoinCollected;
    private void OnDisable() => wallet.CoinsChanged -= OnCoinCollected;

    private void OnCoinCollected(int coins)
    {
        source.PlayOneShot(clip, volume);
    }

    // Короткий "дзинь" з двох нот (B5 -> E6), згенерований кодом.
    private static AudioClip CreateCoinClip()
    {
        const int rate = 44100;
        const float duration = 0.25f;
        const float split = 0.07f;
        int samples = (int)(rate * duration);
        var data = new float[samples];
        float phase = 0f;

        for (int i = 0; i < samples; i++)
        {
            float t = (float)i / rate;
            float freq = t < split ? 988f : 1319f;
            phase += 2f * Mathf.PI * freq / rate;
            float envelope = t < split ? 1f : Mathf.Exp(-(t - split) * 18f);
            float attack = Mathf.Clamp01(t / 0.005f);
            data[i] = Mathf.Sin(phase) * envelope * attack * 0.5f;
        }

        var result = AudioClip.Create("CoinSound_Generated", samples, 1, rate, false);
        result.SetData(data, 0);
        return result;
    }
}
