using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour 
{

	void Update () 
	{
        if (Input.GetKeyDown(KeyCode.F1)) //Debug key to restart
        {
            Restart();
        }	
	}

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
