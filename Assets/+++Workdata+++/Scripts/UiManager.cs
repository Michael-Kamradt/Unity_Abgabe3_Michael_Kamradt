using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement; // Hinzugef�gt

public class UIManager : MonoBehaviour
{
    public GameObject losePanel;
    public GameObject mainMenuPanel;
    public GameObject winPanel;
    public GameObject levelPanel;

    [SerializeField] private TMP_Text cupText; // Textfeld f�r Cup-Anzeige
    [SerializeField] private TMP_Text loseCupText; // Textfeld f�r Cups im LosePanel
    [SerializeField] private TMP_Text winCupText;  // Textfeld f�r Cups im WinPanel
    [SerializeField] private TMP_Text loseTimeText; // Textfeld f�r Zeit im LosePanel
    [SerializeField] private TMP_Text winTimeText;  // Textfeld f�r Zeit im WinPanel

    public void Start()
    {
        ShowMainMenu();
    }

    public void ShowLose(int cupCount, float endTime)
    {
        losePanel.SetActive(true);
        mainMenuPanel.SetActive(false);
        winPanel.SetActive(false);
        levelPanel.SetActive(false);

        if (loseCupText != null)
            loseCupText.text = $"Cups: {cupCount}";
        if (loseTimeText != null)
            loseTimeText.text = $"Zeit: {endTime:0.00}s";
    }

    public void ShowWin(int cupCount, float endTime)
    {
        losePanel.SetActive(false);
        mainMenuPanel.SetActive(false);
        winPanel.SetActive(true);
        levelPanel.SetActive(false);

        if (winCupText != null)
            winCupText.text = $"Cups: {cupCount}";
        if (winTimeText != null)
            winTimeText.text = $"Zeit: {endTime:0.00}s";
    }

    public void ShowMainMenu()
    {
        losePanel.SetActive(false);
        mainMenuPanel.SetActive(true);
        winPanel.SetActive(false);
        levelPanel.SetActive(false);
    }

    public void ShowLevel()
    {
        losePanel.SetActive(false);
        mainMenuPanel.SetActive(false);
        winPanel.SetActive(false);
        levelPanel.SetActive(true);
    }

    public void HideAll()
    {
        losePanel.SetActive(false);
        mainMenuPanel.SetActive(false);
        winPanel.SetActive(false);
        levelPanel.SetActive(false);
    }

    public void Restart()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }

    public void UpdateCupCount(int count)
    {
        if (cupText != null)
            cupText.text = count.ToString();
    }
}
