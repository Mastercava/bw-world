﻿using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	private float speed = 5f;
	
	private Animator animator;
	private Vector2 direction;
	private float lastSpell;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> () as Animator;
		direction = new Vector2(0.0f,-1.0f);
	}


	
	// Update is called once per frame
	void Update () {
		
		if (Input.GetKey (KeyCode.DownArrow)) {
			//transform.position -= transform.up * MoveSpeed * Time.deltaTime;
			animator.Play ("WalkDown");
			direction = new Vector2 (0.0f, -1.0f);
			rigidbody2D.velocity = direction*speed;
		} else if (Input.GetKey (KeyCode.UpArrow)) {
			//transform.position += transform.up * MoveSpeed * Time.deltaTime;
			animator.Play ("WalkUp");
			direction = new Vector2 (0.0f, 1.0f);
			rigidbody2D.velocity = direction*speed;
		} else if (Input.GetKey (KeyCode.LeftArrow)) {
			//transform.position -= transform.right * MoveSpeed * Time.deltaTime;
			animator.Play ("WalkLeft");
			direction = new Vector2 (-1.0f, 0.0f);
			rigidbody2D.velocity = direction*speed;
		} else if (Input.GetKey (KeyCode.RightArrow)) {
			//transform.position += transform.right * MoveSpeed * Time.deltaTime;
			animator.Play ("WalkRight");
			direction = new Vector2 (1.0f, 0.0f);
			rigidbody2D.velocity = direction*speed;
		} else {
			rigidbody2D.velocity = new Vector2(0,0);
		}

		//Input.GetMouseButtonDown(0)
		if(Time.time > lastSpell + 0.1f) {
			if (Input.GetKey (KeyCode.W)) {
				GameInstance.instance.playerCastSpell("Red 1",transform,direction);
				lastSpell = Time.time;
			}
			else if(Input.GetKey (KeyCode.A)) {
				GameInstance.instance.playerCastSpell("Blue 1",transform,direction);
				lastSpell = Time.time;
			}
			else if(Input.GetKey (KeyCode.D)) {
				GameInstance.instance.playerCastSpell("Green 1",transform,direction);
				lastSpell = Time.time;
			}
			else if(Input.GetKey (KeyCode.S)) {
				GameInstance.instance.playerCastSpell("Red 4",transform,direction);
				lastSpell = Time.time;
			}
		}
	}


	void OnCollisionEnter2D (Collision2D other) {
		if (other.gameObject.tag == "SpellEnemy") {
			Spell spellParameters = (Spell)other.gameObject.GetComponent ("Spell");
			GameInstance.instance.damagePlayer(spellParameters.damage);
		} 
	}

}
