using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour 
{
  
private Player player;



    private void Awake()
    {
        int numbGameManagers = FindObjectsOfType<GameManager>().Length;
        if (numbGameManagers > 1)
        {
            Destroy(gameObject);// if there is more than 1  GameManager scripts in the game destroy this one
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }

    }

    // Use this for initialization
    void Start () 
	{
	
	// GameObject.FindWithTag("Player").GetComponent<Player>().currentPlayerHealth.ToString();

	}
			
	// Update is called once per frame
	void Update() 
	{
//if(Player.currentPlayerHealth <=0)
		//{
		//PlayerDeath();
		//}
	}
	
	public void PlayerDeath()
	{
		
		ResetGame();
    }


	public void LoseLife(){
	
		//health--;
		int currentLevelIndex = SceneManager.GetActiveScene ().buildIndex;
		SceneManager.LoadScene (currentLevelIndex);
	}

	private void ResetGame(){
		//SceneManager.LoadScene ("Level1");
		int currentLevelIndex = SceneManager.GetActiveScene ().buildIndex;
		SceneManager.LoadScene (currentLevelIndex);
	

		Debug.Log ("you are dead");
	}
}