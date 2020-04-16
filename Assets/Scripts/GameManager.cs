using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    bool playerActive = false;
    bool gameOver = false;
    private bool gameStart = false;
    [SerializeField] GameObject mainmenu;

    public bool PlayerActive
    {
        get { return playerActive; }
    }
    public bool GameOver
    {
        get { return gameOver; }
    }
    public bool GameStart
    {
        get { return gameStart; }
    }

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else if(instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);

        Assert.IsNotNull(mainmenu);
    }
    public void PlayerCollide()
    {
        gameOver = true;
    }
    public void PlayerStartGame()
    {
        playerActive = true;
    }
    public void EnterGame()
    {
        mainmenu.SetActive(false);
        gameStart = true;
    }
}
