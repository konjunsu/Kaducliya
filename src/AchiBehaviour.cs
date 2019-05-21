using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AchiBehaviour : MonoBehaviour {

	public Achievement[] achis;
	public Text text_achi_desc;
	public Text text_achi_name;
	public Image img_render;
	private Queue<int> achs = new Queue<int> ();

	// Use this for initialization
	void Start () {
		StartCoroutine (AchievementManager ());
	}
	

	public bool ShowAchievement (int achi_id) {
		
		if (achi_id < 0 || achi_id >= achis.Length)
			return false;
		achs.Enqueue (achi_id);
		return true;
	}

	private IEnumerator AchievementManager () {

		while (true) {
			if (achs.Count < 1) {
				yield return new WaitForSeconds (Globals.achi_check);
				continue;
			}

			text_achi_desc.text = achis [achs.Peek ()].achi_desc;
			text_achi_name.text = achis [achs.Peek ()].achi_name;
			img_render.sprite = achis [achs.Dequeue ()].achi_sprite;
			GetComponent<Animator> ().enabled = true;
			GetComponent<Animator> ().Play ("achi_show");
			yield return new WaitForSeconds (Globals.achi_wait);
			GetComponent<Animator> ().Play ("achi_hide");
			yield return new WaitForSeconds (1.0f);
		}

	}
}
