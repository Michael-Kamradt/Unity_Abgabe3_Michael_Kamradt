using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] public float timer = 0f;        // Z�hlt Zeit hoch (Sekunden)
    [SerializeField] public TMP_Text timerText;      // TextMeshPro-Feld f�r Anzeige

    private bool timerRunning = false; // Timer l�uft nur, wenn true

    void Update()
    {
        if (timerRunning)
        {
            // Zeit erh�hen (pro Frame um DeltaTime)
            timer += Time.deltaTime;
        }

        // Anzeige aktualisieren
        if (timerText != null)
        {
            timerText.text = timer.ToString("F2") + " s";
        }
    }

    // Diese Methode kann dem Start-Button zugewiesen werden
    public void StartTimer()
    {
        timer = 0f;
        timerRunning = true;
    }

    // Optional: Timer stoppen
    public void StopTimer()
    {
        timerRunning = false;
    }
}
