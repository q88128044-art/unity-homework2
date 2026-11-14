using UnityEngine;

// Лампа: Toggle() вмикає / вимикає світло.
public class Lamp : MonoBehaviour
{
    [SerializeField] private Light lampLight;
    [SerializeField] private Renderer bulb;
    [SerializeField] private Material onMaterial;
    [SerializeField] private Material offMaterial;
    [SerializeField] private bool isOn;

    private void Awake() => Apply();

    public void Toggle()
    {
        isOn = !isOn;
        Apply();
    }

    public void TurnOn() { isOn = true; Apply(); }
    public void TurnOff() { isOn = false; Apply(); }

    private void Apply()
    {
        if (lampLight != null) lampLight.enabled = isOn;
        if (bulb != null) bulb.sharedMaterial = isOn ? onMaterial : offMaterial;
    }
}
