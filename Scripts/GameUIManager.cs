using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameUIManager : MonoBehaviour
{
    public static GameUIManager instance;
    public int menuIndex;
    public VariableJoystick joystick;

    [Header("Panels")]
    public GameObject panelPlay;
    public GameObject panelPause;
    public GameObject panelEnd;

    [Header("Game")]
    public TMP_Text txtTimer;
    public TMP_Text txtCoins;

    [Header("End")]
    public TMP_Text txtResult;
    public TMP_Text txtScore;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch (GameManager.instance.state)
        {
            case GameState.Play:
                if (!panelPlay.activeInHierarchy)
                    _BtnPlay();
                txtCoins.text = GameManager.instance.score.ToString();
                DisplayTime(GameManager.instance.time);
                break;
            case GameState.Pause:
                if (!panelPause.activeInHierarchy)
                    _BtnPause();
                break;
            case GameState.End:
                break;
        }
    }

    public void _BtnPlay()
    {
        panelPlay.SetActive(true);
        panelPause.SetActive(false);
        panelEnd.SetActive(false);

        GameManager.instance.state = GameState.Play;
    }

    public void _BtnPause()
    {
        panelPlay.SetActive(false);
        panelPause.SetActive(true);
        panelEnd.SetActive(false);

        GameManager.instance.state = GameState.Pause;
    }

    public void GameOver(string result)
    {
        panelPlay.SetActive(false);
        panelPause.SetActive(false);
        panelEnd.SetActive(true);

        GameManager.instance.state = GameState.End;

        txtResult.text = result;
        txtScore.text = GameManager.instance.score.ToString();
    }

    public void _BtnRestart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void _BtnMainMenu()
    {
        SceneManager.LoadScene(menuIndex);
    }

    public void DisplayTime(float time)
    {
        int minutes = (int) time / 60;
        int seconds = (int) time % 60;

        txtTimer.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
