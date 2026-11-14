using UnityEngine;
using UnityEngine.Events;

// Нажимна плита: коли гравець стає на неї — On Pressed, коли сходить — On Released.
// Що саме станеться, налаштовується в інспекторі (UnityEvent), код плити не змінюється.
public class PressurePlate : MonoBehaviour
{
    public UnityEvent onPressed;
    public UnityEvent onReleased;

    [SerializeField] private Transform plateVisual;
    [SerializeField] private float pressDepth = 0.08f;

    private int objectsOnPlate;
    private Vector3 upPosition;

    private void Awake()
    {
        if (plateVisual == null) plateVisual = transform;
        upPosition = plateVisual.localPosition;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        objectsOnPlate++;
        if (objectsOnPlate == 1)
        {
            plateVisual.localPosition = upPosition + Vector3.down * pressDepth;
            onPressed.Invoke();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        objectsOnPlate = Mathf.Max(0, objectsOnPlate - 1);
        if (objectsOnPlate == 0)
        {
            plateVisual.localPosition = upPosition;
            onReleased.Invoke();
        }
    }
}
