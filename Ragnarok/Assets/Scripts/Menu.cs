using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    

public GameObject panel;

    public void PlayGamelevel()
    {
        SceneManager.LoadScene("CharacterSelection");
        //SceneFader.FadTo("Loading");
    }

 

    public void GameMenuControls()
    {
        SceneManager.LoadScene("Controls");
      
    }


    public void QuitGameMenu()
    {

#if UNITY_STANDALONE
        Application.Quit();
#endif

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }


    public void ReturnMenu()
    {
        SceneManager.LoadScene("MainMenu");
        //SceneFader.FadTo("Menu");
     
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag =="Player")
        {
            SceneManager.LoadScene("Win");
        }
    }
}
