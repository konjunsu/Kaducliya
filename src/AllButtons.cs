using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AllButtons : MonoBehaviour {

	public Texture2D cur;
	private GameObject my_cam;

	void Start () {
		//Cursor.SetCursor (cur, Vector2.zero, CursorMode.Auto);
		Globals.timer = new System.Diagnostics.Stopwatch();
		Globals.timer.Reset ();
		Globals.timer.Start ();
	}


    //Start button
    public void StartButton ()
    {
		Globals.collect_copper = true;
		Globals.spawn_troops = true;
		Globals.copper_count = 200;
		SceneManager.LoadScene (1);
    }

	public void ToTitle () {
		SceneManager.LoadScene (0);
	}
}
