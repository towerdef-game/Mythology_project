using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelect : MonoBehaviour
{
    private GameObject[] CharactersList;
    private int index;
  
    // Start is called before the first frame update
    void Start()
    {
        index = PlayerPrefs.GetInt("CharacterSelected");
        CharactersList = new GameObject[transform.childCount];
        for(int i = 0; i < transform.childCount; i++)
            CharactersList[i] =  transform.GetChild(i).gameObject;

              foreach(GameObject go in CharactersList)
              go.SetActive(false);


                if(CharactersList[index])
                CharactersList[index].SetActive(true);
        
    }

    public void ToggleLeft()
    {
        CharactersList[index].SetActive(false);
        index--;
        if(index <0)
        index = CharactersList.Length - 1;

        CharactersList[index].SetActive(true);
    }

     public void ToggleRight()
    {
        CharactersList[index].SetActive(false);
        index++;
        if(index == CharactersList.Length)
        index = 0;

        CharactersList[index].SetActive(true);
    }

    public void Confirm()
    {

        PlayerPrefs.SetInt("CharacterSelected", index);
            SceneManager.LoadScene("CodingMarcus");
        
    }
}
