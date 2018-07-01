using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Opetion : MonoBehaviour {

    private int nChoice = 1;
    public Transform PosOne;
    public Transform PosTwo;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.W))
        {
            nChoice = 1;
            transform.position = PosOne.position;
        }
        else if(Input.GetKeyDown(KeyCode.S))
        {
            nChoice = 2;
            transform.position = PosTwo.position;
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(1);
        }
        else
        {

        }

    }
}
