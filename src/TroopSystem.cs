using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TroopSystem : MonoBehaviour {

	public Troop[] troops;
	public Image[] troop_obj;
	public Text[] costs;
	public GameObject troop_spawn;
	public Image train_counter;

	// Update is called once per frame
	void Start () {
		int i = 0;
		if (troops.Length > troop_obj.Length) {
			foreach (Image img in troop_obj) {
				img.sprite = troops [i].troop_sprite;
				costs [i].text = troops [i].troop_cost.ToString ();
				i++;
			}
		} else {
			foreach (Troop troop in troops) {
				troop_obj [i].sprite = troop.troop_sprite;
				costs [i].text = troop.troop_cost.ToString ();
				i++;
			}
		}
	}

	public bool InstantiateTroop (int troop_id) {
		if (!Globals.spawn_troops)
			return false;
		if (troop_id < 0 || troop_id >= troops.Length)
			return false;
		if (Globals.copper_count < troops [troop_id].troop_cost)
			return false;
		Globals.copper_count -= troops [troop_id].troop_cost;
		Globals.spawn_troops = false;
		StartCoroutine (DoTroopInstantiate (troop_id));
		return true;
	}

	private IEnumerator DoTroopInstantiate (int troop_id) {
		train_counter.fillAmount = 0;
		while (train_counter.fillAmount < 1) {
			train_counter.fillAmount += troops [troop_id].training_time;
			yield return new WaitForSeconds (Globals.duration);
		}
		Instantiate (troops [troop_id].troop_prefab, troop_spawn.transform);
		Globals.spawn_troops = true;
		yield return null;
	}
}
