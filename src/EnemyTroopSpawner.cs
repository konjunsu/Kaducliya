using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTroopSpawner : MonoBehaviour {

	public float delay = 1.0f;
	public EnemyTroop[] spawn_troops;
	public Transform troop_transform;
	private int chance_full;

	private int get_index (int randnum) {
		if (randnum < 1 || randnum > chance_full)
			return spawn_troops.Length - 1;
		for (int i = 0; i < spawn_troops.Length; i++) {
			if (spawn_troops [i].spawn_probability > randnum) {
				return i;			
			}
			randnum -= spawn_troops [i].spawn_probability;
		}
		return 0;
	}

	private IEnumerator SpawnRoutine () {
		int randnum;
		while (true) {
			randnum = Random.Range (1, chance_full);
			Instantiate (spawn_troops[get_index (randnum)].troop_object, troop_transform);
			yield return new WaitForSeconds (delay);		
		}
	}
	
	// Update is called once per frame
	void Start () {
		foreach (EnemyTroop et in spawn_troops)
			chance_full += et.spawn_probability;
		StartCoroutine (SpawnRoutine ());
	}
}
