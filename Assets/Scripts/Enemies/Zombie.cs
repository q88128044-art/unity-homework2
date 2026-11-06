using UnityEngine;

// Zombie is an enemy AND can be interacted with (E): it growls.
public class Zombie : Enemy, IInteractable
{
    private void Reset()
    {
        damage = 8;
    }

    public override void Attack()
    {
        Debug.Log($"Zombie bites! -{damage} HP");
    }

    public void Interact()
    {
        Debug.Log("Zombie growls!");
    }
}
