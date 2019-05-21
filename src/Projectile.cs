using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

	public float speed;
	public int damage;
	public GameObject go;
	private bool IsTarget = false;
	public TroopSide ts;

	// Use this for initialization
	void OnCollisionEnter2D (Collision2D other) {
		TroopBehaviour tb = other.gameObject.GetComponent<TroopBehaviour> ();
		if (tb == null || (other.gameObject != go && go != null) || tb.ts == ts)
			return;
		if (!IsTarget)
			tb.TakeDamage (damage);
		IsTarget = true;
		DestroyObject (gameObject);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		transform.Translate (Vector3.right * speed);	
	}
}
	