using UnityEngine;
using UnityEngine.InputSystem;

// Press F: every enemy attacks. The manager only knows the base class Enemy.
public class EnemyManager : MonoBehaviour
{
    private Enemy[] enemies;

    private void Start()
    {
        enemies = FindObjectsByType<Enemy>();
        Debug.Log($"Enemies on scene: {enemies.Length}. Press F - all enemies attack.");
    }

    private void Update()
    {
        if (Keyboard.current == null || !Keyboard.current.fKey.wasPressedThisFrame) return;

        foreach (Enemy enemy in enemies)
        {
            enemy.Attack();
        }
    }
}
