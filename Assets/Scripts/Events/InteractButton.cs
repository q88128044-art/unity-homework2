using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

// Кнопка: гравець підходить і натискає E — викликається UnityEvent On Pressed.
public class InteractButton : MonoBehaviour
{
    public UnityEvent onPressed;

    [SerializeField] private Transform cap;
    [SerializeField] private GameObject hint;
    [SerializeField] private float pressDepth = 0.06f;

    private bool playerNear;
    private float pressedTimer;
    private Vector3 capUp;

    private void Awake()
    {
        if (cap != null) capUp = cap.localPosition;
        if (hint != null) hint.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        playerNear = true;
        if (hint != null) hint.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        playerNear = false;
        if (hint != null) hint.SetActive(false);
    }

    private void Update()
    {
        var kb = Keyboard.current;
        if (playerNear && kb != null && kb.eKey.wasPressedThisFrame)
        {
            onPressed.Invoke();
            pressedTimer = 0.15f;
        }

        if (cap != null)
        {
            pressedTimer -= Time.deltaTime;
            cap.localPosition = pressedTimer > 0f ? capUp + Vector3.down * pressDepth : capUp;
        }
    }
}
