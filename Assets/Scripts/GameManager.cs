using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static event Action OnStartGame;
    public static event Action OnPlayGame;
    public static event Action OnNotPlayGame;
    public static event Action OnLoseGame;
    public static event Action OnWinGame;
    public static event Action OnControlKey;

    private bool allowEscape = false;
    
    private void OnEnable()
    {
        CharacterManager.OnPlayerDeath += LoseGame;
        CharacterManager.OnFinish += ControlFinish;
        Key.OnKeyCollected += AllowEscape;
    }
    private void OnDisable()
    {
        CharacterManager.OnPlayerDeath -= LoseGame;
        CharacterManager.OnFinish -= ControlFinish;
        Key.OnKeyCollected -= AllowEscape;
    }
    void Start()
    {
        StartGame();
    }

    void AllowEscape()
    {
        allowEscape = true;
    }
    public void StartGame()
    {
        OnStartGame?.Invoke();
        OnNotPlayGame?.Invoke();
    }
    public void PlayGame()
    {
        OnPlayGame?.Invoke();
    }
    public void WinGame()
    {
        OnWinGame?.Invoke();
        OnNotPlayGame?.Invoke();
    }
    public void LoseGame()
    {
        OnLoseGame?.Invoke();
        OnNotPlayGame?.Invoke();
    }
    public void FindKey()
    {
        OnControlKey?.Invoke();
        OnNotPlayGame?.Invoke();
    }
    private void ControlFinish()
    {
        if(allowEscape)
            WinGame();
        else
        {
            FindKey();
        }
    }
    public void Replay()
    {  
        SceneManager.LoadScene("SampleScene");
    }
}
