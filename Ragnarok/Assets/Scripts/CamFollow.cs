using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour {
	private GameObject Player;
	private GameObject Player2;
	private GameObject Player3;
	  private Vector3 offset;

    void Start()
    {
        Player = GameObject.Find("/Player 1/CharacterList/ss_thor_idle_0");
		 Player2 = GameObject.Find("/Player 1/CharacterList/ss_odin_idle_0");
		  Player3 = GameObject.Find("/Player 1/CharacterList/ss_heim_idle_0");
		
		   offset = transform.position - Player.transform.position;
		   offset = transform.position - Player2.transform.position;
		   offset = transform.position - Player3.transform.position;
    }

    void Update()
    {
        transform.position = Player.transform.position + offset;
		 transform.position = Player2.transform.position + offset;
		  transform.position = Player3.transform.position + offset;
    }
}
