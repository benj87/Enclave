﻿using UnityEngine;
using System.Collections;

public class TextSpawn : MonoBehaviour {

	public float scroll=0.03f;
	public float duration=0.7f;
	public float alpha=1f;

	// Use this for initialization
	void Start () {
		//scroll = 0.03f;
	}
	
	// Update is called once per frame
	void Update () {
		if(alpha > 0)
		{
			float ActualPos = transform.position.y;
			ActualPos += scroll * Time.deltaTime;
			alpha -= Time.deltaTime / duration;
			gameObject.transform.position = new Vector3(transform.position.x,ActualPos,0.5f);
		}
		else
		{
			Destroy(gameObject);
		}
	}
}