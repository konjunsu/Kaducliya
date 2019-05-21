using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TroopShooterBehaviour : TroopBehaviour {

	public GameObject projectile;
	public GameObject projectile_point;


	void OnTriggerStay2D (Collider2D other) {
		if (target != null || is_coroutine_running)
			return;
		TroopBehaviour behaviour = other.gameObject.GetComponent<TroopBehaviour> ();
		if (behaviour == null || behaviour.ts == ts) {
			Physics2D.IgnoreCollision (GetComponent<CircleCollider2D> (), other.gameObject.GetComponent<BoxCollider2D> ());
			return;
		}
		speed = 0;
		target = behaviour;
		is_coroutine_running = true;
		StartCoroutine (BeginAttack ());
	}

	void OnCollisionStay2D (Collision2D other) {}

	private IEnumerator BeginAttack () {

		while (true) {
			if (target == null) {
				speed = prev_speed;
				is_coroutine_running = false;
				break;		
			}
			yield return new WaitForSeconds (hit_speed);
			if (target == null) {
				speed = prev_speed;
				is_coroutine_running = false;
				break;			
			}
			GameObject proj = Instantiate (projectile, projectile_point.transform);
			proj.GetComponent<Projectile> ().go = target.gameObject;
		}
		yield return null;

	}

	void Awake () {
		prev_speed = speed;
	}

	// Update is called once per frame
	void FixedUpdate () {
		transform.Translate (Vector3.right * speed);	
	}
}
