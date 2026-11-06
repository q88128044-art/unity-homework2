using UnityEngine;
using UnityEngine.InputSystem;

// Press E: a Raycast is fired from the screen centre, IInteractable is found, Interact() is called.
// No checks for concrete types (Door / Chest / NPC) — only the interface.
[RequireComponent(typeof(Camera))]
public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] private float interactDistance = 4f;
    [SerializeField] private LayerMask interactMask = ~0;

    private Camera cam;

    private void Awake()
    {
        cam = GetComponent<Camera>();
    }

    private void Update()
    {
        if (Keyboard.current != null && Keyboard.current.eKey.wasPressedThisFrame)
        {
            TryInteract();
        }
    }

    public void TryInteract()
    {
        if (cam == null) cam = GetComponent<Camera>();

        Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
        Debug.DrawRay(ray.origin, ray.direction * interactDistance, Color.yellow, 1f);

        if (Physics.Raycast(ray, out RaycastHit hit, interactDistance, interactMask, QueryTriggerInteraction.Ignore))
        {
            IInteractable interactable = hit.collider.GetComponentInParent<IInteractable>();
            if (interactable != null)
            {
                interactable.Interact();
                return;
            }
        }

        Debug.Log($"Nothing to interact with (come closer, max {interactDistance} m)");
    }

    private void OnGUI()
    {
        GUI.Label(new Rect(Screen.width / 2f - 5f, Screen.height / 2f - 12f, 20f, 24f), "+");
        GUI.Label(new Rect(10f, 10f, 520f, 24f), "WASD - move, mouse - look, E - interact, F - enemies attack, Esc - cursor");
    }
}
