﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ColorIndicator : MonoBehaviour {

	private bool isActive;
	private bool canShoot = true;

	public Image redRenderer,greenRenderer,blueRenderer;
	
	public Sprite[] redSprite,greenSprite,blueSprite;

	private float lastSpell;
	private GameObject player;
	private PlayerController controller;

	private bool isLoading = false;
	private float startLoadingTime;
	private int loadedLevel = 0;

	private bool isBlue = false, isGreen = false, isRed = false;
	private bool greenAvailable, blueAvailable, redAvailable;
	private float lastPowerCheck = -6f;

	private Vector4 visible = new Vector4(255,255,255,255);
	private Vector4 hidden = new Vector4(255,255,255,0);

	// Use this for initialization
	void Start () {
		isActive = !Settings.isMobile;
		player = GameInstance.instance.getPlayerGameObject ();
		controller = GameInstance.instance.getPlayerController ();
		checkColors ();
		hide ();
	}
	
	// Update is called once per frame
	void Update () {
		if (isActive) {

			//Pressing
			if(Input.GetKey (KeyCode.W) || Input.GetKey (KeyCode.A) || Input.GetKey (KeyCode.D)) {

				if(!isLoading) {
					isLoading = true;
					startLoadingTime = Time.time;
					show ();
				}
				else {
					if(Time.time > startLoadingTime + 1.5f) loadedLevel = 3;
					else if(Time.time > startLoadingTime + 0.75f) loadedLevel = 2;
					else loadedLevel = 1;
				}
			}
			//Button released
			else if(isLoading) {
				shootSpell();
			}

			if(Input.GetKey (KeyCode.W)) isGreen = true;
			else isGreen = false;
			if(Input.GetKey (KeyCode.A)) isRed = true;
			else isRed = false;
			if(Input.GetKey (KeyCode.D)) isBlue = true;
			else isBlue = false;
			;
			if(isBlue) blueRenderer.sprite = blueSprite[1 + GameInstance.instance.maxSpellLevel("blue",loadedLevel)];
			else blueRenderer.sprite = blueSprite[1];
			if(isRed) redRenderer.sprite = redSprite[1 + GameInstance.instance.maxSpellLevel("red",loadedLevel)];
			else redRenderer.sprite = redSprite[1];
			if(isGreen) greenRenderer.sprite = greenSprite[1 + GameInstance.instance.maxSpellLevel("green",loadedLevel)];
			else greenRenderer.sprite = greenSprite[1];

			if(!greenAvailable) greenRenderer.sprite = greenSprite[0];
			if(!blueAvailable) blueRenderer.sprite = blueSprite[0];
			if(!redAvailable) redRenderer.sprite = redSprite[0];

		}

		//Check for new powers
		if(Time.time > lastPowerCheck + 5f) {
			checkColors();			
		}
	}

	public void shootSpell() {
		castAvailableSpell ();
		loadedLevel = 0;
		isLoading = false;
		isBlue = false;
		isRed = false;
		isGreen = false;
		resetColors ();
		hide ();
	}

	private void hide () {
		blueRenderer.color = hidden;
		redRenderer.color = hidden;
		greenRenderer.color = hidden;
	}

	private void show () {
		blueRenderer.color = visible;
		redRenderer.color = visible;
		greenRenderer.color = visible;
	}

	private void castAvailableSpell() {
		string spellName = GameInstance.instance.selectAvailableSpell (isRed && redAvailable, isGreen && greenAvailable, isBlue && blueAvailable, loadedLevel);
		bool status = GameInstance.instance.playerCastSpell (spellName);
	}

	private void resetColors() {
		blueRenderer.sprite = blueSprite[1];
		redRenderer.sprite = redSprite[1];
		greenRenderer.sprite = greenSprite[1];
	}

	//Check for new powers
	void checkColors() {
		lastPowerCheck = Time.time;
		int storyLevel = QuestManager.instance.getStoryLevel();
		if(storyLevel>=Settings.greenStoryLevel) greenAvailable = true;
		else greenAvailable = false;
		if(storyLevel>=Settings.blueStoryLevel) blueAvailable = true;
		else blueAvailable = false;
		if(storyLevel>=Settings.redStoryLevel) redAvailable = true;
		else redAvailable = false;
	}

	public void showStatsPanel() {

	}

}
