using UnityEngine;

// Пара дверей: дві стулки роз'їжджаються в сторони. Методи Open/Close викликаються з UnityEvent.
public class DoorPair : MonoBehaviour
{
    [SerializeField] private Transform leftLeaf;
    [SerializeField] private Transform rightLeaf;
    [SerializeField] private float openDistance = 1.4f;
    [SerializeField] private float speed = 3f;

    private Vector3 leftClosed, rightClosed;
    private bool isOpen;

    private void Awake()
    {
        leftClosed = leftLeaf.localPosition;
        rightClosed = rightLeaf.localPosition;
    }

    public void Open() => isOpen = true;
    public void Close() => isOpen = false;

    private void Update()
    {
        Vector3 leftTarget = isOpen ? leftClosed + Vector3.left * openDistance : leftClosed;
        Vector3 rightTarget = isOpen ? rightClosed + Vector3.right * openDistance : rightClosed;
        leftLeaf.localPosition = Vector3.MoveTowards(leftLeaf.localPosition, leftTarget, speed * Time.deltaTime);
        rightLeaf.localPosition = Vector3.MoveTowards(rightLeaf.localPosition, rightTarget, speed * Time.deltaTime);
    }
}
