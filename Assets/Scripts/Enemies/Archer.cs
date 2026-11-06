using UnityEngine;

// Archer attacks from distance.
public class Archer : Enemy
{
    [SerializeField] private float range = 15f;

    private void Reset()
    {
        damage = 12;
    }

    public override void Attack()
    {
        Debug.Log($"Archer shoots an arrow from {range} m! -{damage} HP");
    }
}
