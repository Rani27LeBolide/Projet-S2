using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Option : MonoBehaviour {
    float volume = 0.5f;
	// Update is called once per frame
    void Start()
    {
        
        AudioListener.volume = volume;
    }
    public void AdjustVolum(float newvolume)
    {
        
        AudioListener.volume = newvolume;
    }
    public bool Fullscreen()
    {
        return true;
    }
    
   
}
