using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bouttons : MonoBehaviour {
    
    public void loadmapmontagne ()
    {
        SceneManager.LoadScene("Map montagne");
    }
    public void loadmapselectionmenu ()
    {
        SceneManager.LoadScene("Selection map");
    }
}
