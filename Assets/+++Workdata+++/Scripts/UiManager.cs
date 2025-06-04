using UnityEngine;
using TMPro;

public class UiManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerText; // TMP Text für den Timer
    [SerializeField] private GameObject startButton; // Start-Button als Referenz

    private float levelTime = 300f; // Startzeit: 5 Minuten
    private bool isGameActive = false; // Timer läuft nur, wenn true

    private void Update()
    {
        if (isGameActive && levelTime > 0f)
        {
            levelTime -= Time.deltaTime; // Zeit verringern
            UpdateTimerUI(); // Anzeige aktualisieren
        }
        else if (levelTime <= 0f && isGameActive)
        {
            levelTime = 0f;
            isGameActive = false;
            Debug.Log("Zeit ist abgelaufen! Game Over!");
            // Hier kannst du Lost-Screen oder Ähnliches aktivieren
        }
    }

    private void UpdateTimerUI()
    {
        // In Minuten, Sekunden und Millisekunden umwandeln
        int minutes = Mathf.FloorToInt(levelTime / 60f);
        int seconds = Mathf.FloorToInt(levelTime % 60f);
        int milliseconds = Mathf.FloorToInt((levelTime * 1000f) % 1000f / 10f); // 2-stellige ms

        // Formatierung: MM:SS:MS (MS = 2-stellig)
        timerText.text = string.Format("{0:00}:{1:00}:{2:00}", minutes, seconds, milliseconds);
    }

    // Wird aufgerufen, wenn der Button geklickt wird
    public void StartTimer()
    {
        isGameActive = true;
        startButton.SetActive(false); // Button ausblenden, wenn Spiel startet
    }

    // Wird aufgerufen, wenn der Spieler das Ende des Levels erreicht
    public void StopTimer()
    {
        if (isGameActive)
        {
            isGameActive = false; // Timer stoppen
            Debug.Log("Level geschafft in: " + timerText.text);
        }
    }
}
