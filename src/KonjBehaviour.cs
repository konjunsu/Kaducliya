using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KonjBehaviour : TroopBehaviour {

	public float speed_2;
	public int charge_damage;
	private bool did_dmg = false;

	void Awake () {
		prev_speed = speed_2;
	}

	void OnCollisionEnter2D (Collision2D other) {
		if (did_dmg)
			return;
		TroopBehaviour beh = other.gameObject.GetComponent<TroopBehaviour> ();
		if (beh == null || beh.ts == ts)
			return;
		did_dmg = true;
		beh.TakeDamage (charge_damage);
		speed = prev_speed;
	}

}
