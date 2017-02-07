using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityStandardAssets.ImageEffects;

public class GameUI : MonoBehaviour
{
    public GameObject gameOverScreen;
    public Text secondsSurvivedUIText;

    public GameObject gameStartScreen;
    public ColorCorrectionCurves colorCorrection;
    private Spawner spawner;
    private void GameOver()
    {
        spawner.isStartGame = false;

        gameOverScreen.SetActive(true);
        secondsSurvivedUIText.text = Mathf.RoundToInt(FindObjectOfType<Timers>().Seconds).ToString();
    }

    public void StartGame()
    {
        spawner.isStartGame = true;
        gameStartScreen.SetActive(false);
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene(0);
    }

    private void Start()
    {
        FindObjectOfType<PlayerController>().OnPlayerDeath += GameOver;
        spawner = FindObjectOfType<Spawner>();
    }

    private void Update()
    {
        if(Input.GetKey(KeyCode.Escape))
            Application.Quit();

        if (!spawner.isStartGame) return;
        if (colorCorrection.saturation >= 1.0f) return;
        colorCorrection.saturation += 0.025f;
    }

}
