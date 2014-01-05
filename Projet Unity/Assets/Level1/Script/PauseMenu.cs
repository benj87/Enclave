﻿using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour {

	public GUISkin mySkin;

	private Rect windowRect = new Rect (Screen.width/2 - 400/2, Screen.height/2 - 500/2, 400, 500);

	private bool Pause = false;
	private bool PauseM = false;
	private bool Instruc = false;
	private float timeScale = 1.0f; 

	private Texture2D ForwarKey;
	private Texture2D BackKey;
	private Texture2D LeftKey;
	private Texture2D RightKey;

	void Start () 
	{
		mySkin = Resources.Load("EnclaveSkin") as GUISkin;
		ForwarKey = Resources.Load("GUI/Commandes/forward") as Texture2D;
		BackKey = Resources.Load("GUI/Commandes/back") as Texture2D;
		LeftKey = Resources.Load("GUI/Commandes/left") as Texture2D;
		RightKey = Resources.Load("GUI/Commandes/right") as Texture2D;
	}
	// Use this for initialization
	void OnGUI ()
	{
		//Attribution du style a utilisé
		GUI.skin = mySkin;
		
		if(PauseM)
		{
			windowRect = GUI.Window (0, windowRect, DoMyPause, "");
		}
		if(Instruc)
		{
			windowRect = GUI.Window (0, windowRect, DoMyInstruc, "");
		}
	}

	void Update () 
	{
		if(!PauseM)
		{
			if (Input.GetKeyDown (KeyCode.P)) 
			{
				Pause = true;
				PauseM = !PauseM;
				if(Pause)
				{
					timeScale = Time.timeScale;
				}
				else
				{
					Time.timeScale = 1;
				}
			}
		}
		
		if(Pause)
			Time.timeScale = 0.0f; 
	}

	
	void DoMyPause(int windowID)
	{
		GUILayout.Label ("PAUSE", "Label");
		GUILayout.Space(50);
		if(GUILayout.Button("Reprendre", "Button"))
		{
			PauseM = false;
			Pause = false;
			if(Pause)
				timeScale = Time.timeScale;
			if(!Pause)
				Time.timeScale = 1.0f; 
		}
		GUILayout.Space(30);
		if(GUILayout.Button("Commandes", "Button"))
		{
			PauseM = false;
			Instruc = true;
		}
		GUILayout.Space(30);
		if(GUILayout.Button("Quitter", "Button"))
		{
			Application.LoadLevel(0);
		}
	}
	
	void DoMyInstruc(int windowID)
	{
		GUILayout.Label ("Commandes", "Label");
		GUILayout.Space(60);
		GUILayout.Label("Deplacements","Normal");
		GUI.DrawTexture(new Rect(250,150,40,40), ForwarKey);
		GUI.DrawTexture(new Rect(250,190,40,40), BackKey);
		GUI.DrawTexture(new Rect(210,190,40,40), LeftKey);
		GUI.DrawTexture(new Rect(290,190,40,40), RightKey);
		GUILayout.Space(100);
		if(GUILayout.Button("Retour", "Button"))
		{
			Instruc = false;
			PauseM = true;
		}
	}
}
