using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI materialText;
    public TextMeshProUGUI dayCountText;
    public Button restartButton;
    public GameObject TitleScreen;
    public GameObject GameOverScreen;
    public GameObject GameWonScreen;

    public bool gameActive = false;

    private int matCount = 0;
    private int dayCount = 0;

    private int WinCondition;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void StartGame(int difficulty)
    {
        gameActive = true;
        matCount = 0;
        dayCount = -1;
        WinCondition = difficulty;
        UpdateMaterials(0);
        UpdateDay();
        TitleScreen.gameObject.SetActive(false);
    }

    public void UpdateMaterials(int mats)
    {
        matCount = mats;
        materialText.SetText("Materials: " + matCount);
    }

    public void UpdateDay()
    {
        dayCount++;
        dayCountText.SetText("Night: " + dayCount);
        if(dayCount == WinCondition) { GameWon(); }
    }

    public void GameWon()
    {
        gameActive = false;
        GameWonScreen.gameObject.SetActive(true);
    }

    public void GameOver()
    {
        gameActive = false;
        GameOverScreen.gameObject.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
