using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager_scp : MonoBehaviour
{
    private bool M_Isplayerdead=false;
    void Start()
    {
             
    }

    void Update()
    {
        Restart();
        Exit_Menu();
    }
    void Restart()
    {
       if(Input.GetKeyDown(KeyCode.R) && M_Isplayerdead==true )
        {
            SceneManager.LoadScene(1);
        }
    }
    void Exit_Menu()
    {
        if (Input.GetKeyDown(KeyCode.E) && M_Isplayerdead == true)
        {
            SceneManager.LoadScene(0);
        }
    }

    public void playerdies()
    {
        M_Isplayerdead = true;
    }
}
