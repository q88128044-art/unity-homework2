using UnityEngine;

// Камера слідує за гравцем зверху-ззаду.
public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private Vector3 offset = new Vector3(0f, 9f, -9f);
    [SerializeField] private float smooth = 8f;

    private void LateUpdate()
    {
        if (target == null) return;
        transform.position = Vector3.Lerp(transform.position, target.position + offset, smooth * Time.deltaTime);
        transform.LookAt(target.position);
    }
}
