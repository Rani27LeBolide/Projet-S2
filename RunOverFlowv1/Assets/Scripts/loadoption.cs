using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loadoption : MonoBehaviour
{
    GameObject target;
    Scene option;
    
    public void loadmap()
    {
        
        target = GameObject.FindGameObjectWithTag("musique");
        DontDestroyOnLoad(target);
        SceneManager.LoadScene("Option");
    }
}
