﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Test for commit change

public class PlayerCharacter : MonoBehaviour {
    private int _health;

	// Use this for initialization
	void Start () {
        _health = 5;	
	}

    public void Hurt(int damage)
    {
        _health -= damage;

        Debug.Log("Health: " + _health);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
