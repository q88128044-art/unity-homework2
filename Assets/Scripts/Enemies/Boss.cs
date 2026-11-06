using UnityEngine;

// Boss: normal axe attack, every 3rd attack is a special one (triple damage).
public class Boss : Enemy
{
    private int attackCount;

    private void Reset()
    {
        damage = 25;
    }

    public override void Attack()
    {
        attackCount++;
        if (attackCount % 3 == 0)
        {
            Debug.Log($"Boss uses EARTHQUAKE! -{damage * 3} HP to everyone around");
        }
        else
        {
            Debug.Log($"Boss swings his giant axe! -{damage} HP");
        }
    }
}
