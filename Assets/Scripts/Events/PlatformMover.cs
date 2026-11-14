using UnityEngine;

// Платформа: MoveUp() піднімає, MoveDown() опускає.
// Підключається до On Pressed / On Released плити через інспектор, PressurePlate.cs не змінюється.
public class PlatformMover : MonoBehaviour
{
    [SerializeField] private float height = 3f;
    [SerializeField] private float speed = 2f;

    private Vector3 downPosition;
    private Vector3 upPosition;
    private Vector3 target;

    private void Awake()
    {
        downPosition = transform.position;
        upPosition = downPosition + Vector3.up * height;
        target = downPosition;
    }

    public void MoveUp() => target = upPosition;
    public void MoveDown() => target = downPosition;

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
    }
}
