﻿using UnityEngine;
using System.Collections;

public class PuzzleMaster : MonoBehaviour {

	// 0 = Red
	// 1 = Green
	// 2 = Blue
	public int[] correctSequence;
	public bool RandomSequence = false;

	public int attempt = 0;
	public bool active = true;
	public GameObject door;

	public int _min = 3;
	public int _max = 5;

	// Use this for initialization
	void Start () {
		if (RandomSequence)
			RandomInitialization ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private void RandomInitialization(){
		var size = Random.Range (_min, _max + 1);
		correctSequence = new int[size];
		int addToSequence;
		for (int i = 0; i<size; i++) {
			addToSequence = Random.Range(0,3);	
			while(i!=0 && correctSequence[i-1]==addToSequence) {
				addToSequence = Random.Range(0,3);
			}
			correctSequence[i] = addToSequence;	
		}
	}

	public int Size (){
		return correctSequence.Length;
	}
}
