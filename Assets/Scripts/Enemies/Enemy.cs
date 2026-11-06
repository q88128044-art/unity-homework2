using UnityEngine;

// Base class for all enemies. Every enemy must have its own attack.
public abstract class Enemy : MonoBehaviour
{
    [SerializeField] protected int damage = 10;

    public abstract void Attack();
}
