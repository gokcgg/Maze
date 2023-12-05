using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
 

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject keyIcon, mapIcon, miniMap, startScreen, gameScreen, winScreen, loseScreen, keyInfoPanel;
    public Slider healthBar;
    
    private static float finalHealth;
    public bool healthReduce = false;
    public bool healthIncrease = false;
    
    private void OnEnable()
    {
        GameManager.OnStartGame += StartGameUI;
        GameManager.OnPlayGame += PlayGameUI;
        GameManager.OnWinGame += WinGameUI;
        GameManager.OnLoseGame += LoseGameUI;
        GameManager.OnControlKey += KeyInfo;

        Map.OnMapCollected += CollectMap;
        Key.OnKeyCollected += CollectKey;
        Health.OnHealthCollected += Heal;
        BasicObstacle.OnBasicDamage += Damage;
        AdvancedObstacle.OnAdvancedDamage += Die;
        
    }

    private void OnDisable()
    {  
        GameManager.OnStartGame -= StartGameUI;
        GameManager.OnPlayGame -= PlayGameUI;
        GameManager.OnWinGame -= WinGameUI;
        GameManager.OnLoseGame -= LoseGameUI;
        GameManager.OnControlKey -= KeyInfo;
        
        Map.OnMapCollected -= CollectMap;
        Key.OnKeyCollected -= CollectKey;
        Health.OnHealthCollected -= Heal;
        BasicObstacle.OnBasicDamage -= Damage;
        AdvancedObstacle.OnAdvancedDamage -= Die;
    }

    private void Update()
    {
        if (healthReduce)
        {
            healthBar.value = (healthBar.value - 0.01f);
                
            if (healthBar.value <= 0.05)
            {
                LoseGameUI();
            }
            else if (healthBar.value <= finalHealth)
            {
                healthReduce = false;
            }
        }

        if (healthIncrease)
        {
            healthBar.value = (healthBar.value + 0.01f);
            
            if (healthBar.value >= finalHealth)
            {
                healthIncrease = false;
            }
        }
    }

    void CollectKey()
    {
        keyIcon.gameObject.SetActive(true);
    }
    void CollectMap()
    {
        mapIcon.gameObject.SetActive(true);
        miniMap.gameObject.SetActive(true);
    } 
    void Heal()
    {
        if (healthBar.value <= 0.65)
        {
            finalHealth = healthBar.value + 0.35f;
            healthIncrease = true;
        }
    }

    void Damage()
    {
        finalHealth = healthBar.value - 0.35f;
        healthReduce = true;
    }

    void Die()
    {
        LoseGameUI();
    }
    
    public void WinGameUI()
    {
        winScreen.gameObject.SetActive(true);
        gameScreen.gameObject.SetActive(false);
        loseScreen.gameObject.SetActive(false);
        startScreen.gameObject.SetActive(false);
        keyInfoPanel.gameObject.SetActive(false);
    }
    public  void LoseGameUI()
    {
        loseScreen.gameObject.SetActive(true);
        gameScreen.gameObject.SetActive(false);
        winScreen.gameObject.SetActive(false);
        startScreen.gameObject.SetActive(false);
        keyInfoPanel.gameObject.SetActive(false);
    }
    public   void StartGameUI()
    {
        loseScreen.gameObject.SetActive(false);
        gameScreen.gameObject.SetActive(false);
        winScreen.gameObject.SetActive(false);
        startScreen.gameObject.SetActive(true);
        keyInfoPanel.gameObject.SetActive(false);
    }
    public void PlayGameUI()
    {
        loseScreen.gameObject.SetActive(false);
        gameScreen.gameObject.SetActive(true);
        winScreen.gameObject.SetActive(false);
        startScreen.gameObject.SetActive(false);
        keyInfoPanel.gameObject.SetActive(false);
    }
    
    public void KeyInfo()
    {
        loseScreen.gameObject.SetActive(false);
        gameScreen.gameObject.SetActive(false);
        winScreen.gameObject.SetActive(false);
        startScreen.gameObject.SetActive(false);
        keyInfoPanel.gameObject.SetActive(true);

    }
}
