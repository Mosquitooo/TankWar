using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour {

    private SpriteRenderer sr;
    public Sprite BrokenSprite;
	// Use this for initialization
	void Start () {
        sr = GetComponent<SpriteRenderer>();
	}

    private void Die()
    {
        sr.sprite = BrokenSprite;
    }
}
