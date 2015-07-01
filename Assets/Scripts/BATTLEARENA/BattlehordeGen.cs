﻿using UnityEngine;
using System.Collections;

public class BattlehordeGen : MonoBehaviour {

	private int number_enemies_to_gen = 1;
	private bool enemies_alive;
	public GameObject [] enemies_to_create;
	private GameObject [] enemies_on_game;
	public GameObject player;
	int type_of_enemy;


	// Use this for initialization
	void Start () {
		create_Random_swarm ();
	}

	void create_Random_swarm (){

		//enemies_alive = true;

		int x = Random.Range (0, 2);
		type_of_enemy = x;
		print(enemies_to_create [type_of_enemy].name);	
		int cor = Random.Range (0, 2);

		int pos_x;

		if (cor == 0) {
			pos_x = 7;		
		} else if (cor == 1) {
			pos_x = -7;
		} else {
			pos_x = 0;
		}

		cor = Random.Range (0, 2);
		int pos_y;

		if (cor == 0) {
			pos_y = 7;		
		} else if (cor == 1) {
			pos_y = -7;
		} else {
			pos_y = 0;
		}

		int i = 0;
		enemies_on_game = new GameObject[number_enemies_to_gen];

		for (i=0; i<number_enemies_to_gen; i++) {
			if (x == 0) {
				enemies_on_game[i] = (GameObject) Instantiate (enemies_to_create [0], new Vector2 (player.transform.position.x+pos_x,player.transform.position.y+ pos_y), Quaternion.identity);	
			} else if (x == 1) {
				enemies_on_game[i] = (GameObject) Instantiate (enemies_to_create [1], new Vector2 (player.transform.position.x+pos_x,player.transform.position.y+ pos_y), Quaternion.identity);	
			} else {
				enemies_on_game[i] = (GameObject) Instantiate (enemies_to_create [2], new Vector2 (player.transform.position.x+pos_x,player.transform.position.y+ pos_y), Quaternion.identity);	
			}
		}
	}

	void check_status(){

		int i;
		int dead_guys = 0;
		for (i=0; i<number_enemies_to_gen; i++) {
			if(enemies_on_game[i] == null ){
				dead_guys++;
			}
		}
		if (dead_guys == number_enemies_to_gen) {
			number_enemies_to_gen++;
			create_Random_swarm();
		}
	}
	
		
	// Update is called once per frame
	void Update () {

	 check_status ();

	}
}