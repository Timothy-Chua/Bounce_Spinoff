using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameState state;

    public float time;
    public int score;

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
        Screen.orientation = ScreenOrientation.LandscapeLeft;
        state = GameState.Play;
    }

    // Update is called once per frame
    void Update()
    {
        if (state == GameState.Play)
        {
            time += Time.deltaTime;
        }
    }

    public void CoinCollected()
    {
        score += 1;
        GameUIManager.instance.txtCoins.text = score.ToString();
    }

    public void GameOver(string result)
    {
        state = GameState.End;
        GameUIManager.instance.GameOver(result);
    }
}

public enum GameState
{
    Play, Pause, End
}
