﻿using UnityEngine;
using System.Collections;

public class DoorEneTutEnemy : MonoBehaviour {

	private GameObject enem_1;
	private GameObject enem_2;

	private EnemyController lv_1;
	private EnemyController lv_2;

	private GameObject door;
	private BoxCollider2D col;


	// Use this for initialization
	void Start () {
	
		enem_1 = GameObject.Find ("TutEnemy_1");
		lv_1 =  enem_1.GetComponent<EnemyController> ();
		//lever_1 = GameObject.FindGameObjectWithTag ("lever");
		enem_2 = GameObject.Find ("TutEnemy_2");
		lv_2 = enem_2.GetComponent<EnemyController> ();

		door = GameObject.FindGameObjectWithTag ("Door");
		col = gameObject.GetComponent<BoxCollider2D> ();


	}


	void unlock(){

		col.isTrigger = false;

		if (lv_1.getHealth() <= 0 && lv_2.getHealth() <= 0) {

			Destroy(gameObject);
		}
		
	}

	
	// Update is called once per frame
	void Update () {

		//col.isTrigger = false;
		unlock ();
	}
}
