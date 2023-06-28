using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class TitleScreen : MonoBehaviour
{
    public void Go(){
        SceneManager.LoadScene("Game");
    }

    public void Quit(){
        Application.Quit();
    }
}
