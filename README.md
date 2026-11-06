# Домашнє завдання: інтерфейси та абстрактні класи (Unity 6)

Unity 6000.4.10f1, URP, Input System. Сцена: `Assets/Scenes/SampleScene.unity`.

## 🟢 Базовий рівень
- `IInteractable` з методом `void Interact()` — `Assets/Scripts/Interaction/IInteractable.cs`
- `Door` — відчиняються / зачиняються (плавний поворот).
- `Chest` — відкривається / закривається, золото дає лише перший раз.
- `NPC` — по черзі каже репліки діалогу.

## 🟡 Середній рівень
- `PlayerInteraction` (`Assets/Scripts/Player/PlayerInteraction.cs`): при натисканні **E** запускається Raycast з центру екрана,
  знаходиться `IInteractable` (`GetComponentInParent<IInteractable>()`) і викликається `Interact()`.
- Перевірок `if (Door)` / `if (Chest)` / `if (NPC)` немає — тільки інтерфейс.

## 🔴 Складний рівень
- `public abstract class Enemy` з методом `public abstract void Attack();` — `Assets/Scripts/Enemies/Enemy.cs`
- `Zombie` — кусає; `Archer` — стріляє з лука; `Boss` — б'є сокирою, кожна третя атака — землетрус (потрійна шкода).
- `Zombie` також реалізує `IInteractable` і при взаємодії пише **Zombie growls!**
- `EnemyManager`: на **F** атакують усі вороги (працює лише через базовий клас `Enemy`).

## Керування
WASD — рух, миша — огляд, **E** — взаємодія (до 4 м, приціл «+»), **F** — атака всіх ворогів, Esc — курсор.
Повідомлення виводяться в Console і на екран (`ScreenLog`).
