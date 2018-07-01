using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerManager : MonoBehaviour {
    public int nLife = 1;
    public int nScore = 0;

    public Text PlayerScore;
    public GameObject ImgGameOver;

    private static playerManager instance;

    public static playerManager Instance
    {
        get
        {
            return instance;
        }

        set
        {
            instance = value;
        }
    }

    private void Awake()
    {
        instance = this;
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        PlayerScore.text = nScore.ToString();
        if(nLife <= 0)
        {
            ImgGameOver.SetActive(true);
        }
	}

}
