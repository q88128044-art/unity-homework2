using System.Collections.Generic;
using UnityEngine;

// Shows the last game messages (Debug.Log) on screen, so they are visible without the Console window.
// Created automatically when the game starts — no need to add it to the scene.
public class ScreenLog : MonoBehaviour
{
    private const int MaxLines = 6;
    private readonly Queue<string> lines = new Queue<string>();
    private GUIStyle style;

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
    private static void Create()
    {
        new GameObject("ScreenLog").AddComponent<ScreenLog>();
    }

    private void OnEnable()
    {
        Application.logMessageReceived += OnLog;
    }

    private void OnDisable()
    {
        Application.logMessageReceived -= OnLog;
    }

    private void OnLog(string message, string stackTrace, LogType type)
    {
        lines.Enqueue(message);
        while (lines.Count > MaxLines) lines.Dequeue();
    }

    private void OnGUI()
    {
        if (style == null)
        {
            style = new GUIStyle(GUI.skin.label) { fontSize = 18 };
            style.normal.textColor = Color.white;
        }

        float y = Screen.height - 30f * (lines.Count + 1);
        foreach (string line in lines)
        {
            GUI.Label(new Rect(12f, y, Screen.width - 24f, 28f), line, style);
            y += 28f;
        }
    }
}
