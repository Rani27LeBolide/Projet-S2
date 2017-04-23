using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loadsolomulti : MonoBehaviour

    {
    GameObject target;
        public void loadmap()
        {
            target = GameObject.FindGameObjectWithTag("musique");
            DontDestroyOnLoad(target);
            SceneManager.LoadScene("SoloMulti");
        }
	
    }
