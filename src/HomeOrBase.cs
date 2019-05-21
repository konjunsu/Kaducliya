using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HomeOrBase : TroopBehaviour {

	public GameObject[] cleaning_objects;
	public GameObject endgame;
	public GameObject die_anim;
	public Sprite die_sprite;
	public Text endgame_text;
	public Text endgame_time;
	public AchiBehaviour behav;
	public HomeOrBase other_base;
	private bool isOver = false;

	// Use this for initialization
	void OnCollisonEnter2D (Collision2D other) {}
	void OnCollisionExit2D (Collision2D other) {}

	protected override void Die () {
		if (isOver)
			return;
		isOver = true;
		GetComponent<SpriteRenderer> ().sprite = die_sprite;
		Instantiate (die_anim, transform);
		Globals.collect_copper = false;
		foreach (GameObject go in cleaning_objects) {
			DestroyObject (go);
		}
		if (ts == TroopSide.EnemyTroop) {
			endgame_text.text = "Win is win";
			if (behav != null && other_base.health == other_base.max_health)
				behav.ShowAchievement (0);
			if (Globals.timer.Elapsed.TotalSeconds < 120.0)
				behav.ShowAchievement (1);
		} else {
			endgame_text.text = "Ju lus";
		}
		endgame_time.text = string.Format("{0:D2}:{1:D2}:{2:D2}", Globals.timer.Elapsed.Hours, Globals.timer.Elapsed.Minutes, Globals.timer.Elapsed.Seconds);
			//Globals.timer.Elapsed.Hours.ToString () + ":" + Globals.timer.Elapsed.Minutes.ToString () + ":" + Globals.timer.Elapsed.Seconds.ToString ();
		Globals.timer.Stop ();
		endgame.SetActive (true);
	}

	// Update is called once per frame
	void FixedUpdate () {}
}
