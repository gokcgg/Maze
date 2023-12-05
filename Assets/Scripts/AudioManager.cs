using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    public AudioSource auidoSource;
    public AudioClip keySound, mapSound, healSound, basicObstacleSound, advancedObstacleSound;
  
    private void OnEnable()
    { 
        Map.OnMapCollected += PlayMapSound;
        Key.OnKeyCollected += PlayKeySound;
        Health.OnHealthCollected += PlayHealthSound;
        BasicObstacle.OnBasicDamage += PlayBasicObstacleSound;
        AdvancedObstacle.OnAdvancedDamage += PlayAdvancedObstacleSound;

    }

    private void OnDisable()
    {
        Map.OnMapCollected -= PlayMapSound;
        Key.OnKeyCollected -= PlayKeySound;
        Health.OnHealthCollected -= PlayHealthSound;
        BasicObstacle.OnBasicDamage -= PlayBasicObstacleSound;
        AdvancedObstacle.OnAdvancedDamage -= PlayAdvancedObstacleSound;
    }
    public void PlayAudioClip(AudioClip clip)
    {
        auidoSource.PlayOneShot(clip);
    }
    public void PlayMapSound()
    {
        PlayAudioClip(mapSound);
    
    }
    public void PlayKeySound()
    {
        PlayAudioClip(keySound);
    }
    public void PlayHealthSound()
    {
        PlayAudioClip(healSound);
    
    }
    public void PlayBasicObstacleSound()
    {
        PlayAudioClip(basicObstacleSound);
    
    }
    public void PlayAdvancedObstacleSound()
    {
        PlayAudioClip(advancedObstacleSound);
    
    }
   
}
