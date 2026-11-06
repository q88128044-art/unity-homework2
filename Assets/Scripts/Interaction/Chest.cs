using UnityEngine;

// Chest: opens and closes on E. Gold is given only the first time.
public class Chest : MonoBehaviour, IInteractable
{
    [SerializeField] private int gold = 50;
    [SerializeField] private Transform lid;

    private bool isOpen;
    private bool goldTaken;
    private Vector3 lidClosedPosition;
    private Quaternion lidClosedRotation;

    private void Awake()
    {
        if (lid == null) lid = transform.Find("Lid");
        if (lid != null)
        {
            lidClosedPosition = lid.localPosition;
            lidClosedRotation = lid.localRotation;
        }
    }

    public void Interact()
    {
        isOpen = !isOpen;

        if (isOpen && !goldTaken)
        {
            goldTaken = true;
            Debug.Log($"Chest: opened! You found {gold} gold");
        }
        else
        {
            Debug.Log(isOpen ? "Chest: opened, it is empty" : "Chest: closed");
        }

        if (lid != null)
        {
            lid.localPosition = isOpen ? lidClosedPosition + new Vector3(0f, 0.25f, 0.3f) : lidClosedPosition;
            lid.localRotation = isOpen ? Quaternion.Euler(-70f, 0f, 0f) : lidClosedRotation;
        }
    }
}
