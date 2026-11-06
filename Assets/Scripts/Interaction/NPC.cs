using UnityEngine;

// NPC: says the next line of dialogue each time.
public class NPC : MonoBehaviour, IInteractable
{
    [SerializeField] private string npcName = "Villager";
    [SerializeField] private string[] lines =
    {
        "Hello, traveler!",
        "Zombies came from the forest last night.",
        "Be careful, the Boss is near the tower."
    };

    private int index;

    public void Interact()
    {
        if (lines.Length == 0) return;
        Debug.Log($"{npcName}: {lines[index]}");
        index = (index + 1) % lines.Length;
    }
}
