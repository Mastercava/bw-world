﻿using UnityEngine;
using System.Collections;

public class PuzzleMaster : MonoBehaviour {

	// 0 = Red
	// 1 = Green
	// 2 = Blue
	public int[] correctSequence = new int[]{0,1,2};

	public int attempt = 0;
	public bool active = true;
	public GameObject door;

	private int _min = 3;
	private int _max = 5;

	// Use this for initialization
	void Start () {
		RandomInitialization ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private void RandomInitialization(){
		var size = Random.Range (_min, _max + 1);
		correctSequence = new int[size];
		for (int i = 0; i<size; i++) {
			correctSequence[i] = Random.Range(0,3);	
		}
	}

	public int Size (){
		return correctSequence.Length;
	}
}
