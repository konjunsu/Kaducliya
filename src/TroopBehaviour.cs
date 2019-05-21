using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum TroopSide {
	PlayerTroop,
	EnemyTroop
};

public class TroopBehaviour : MonoBehaviour {

	public float speed = 1.0f;
	public float hit_speed = 1.0f;
	public int damage;
	public int max_health;
	[SerializeField] protected int health;
	public TroopSide ts;
	protected float prev_speed;
	protected TroopBehaviour target = null;
	[SerializeField] protected Image helt;
	protected bool is_coroutine_running = false;

	// Update is called once per frame
	void FixedUpdate () {
		transform.Translate (Vector3.right * speed);	
	}

	void OnCollisionStay2D (Collision2D other) {
		if (target != null || is_coroutine_running)
			return;
		TroopBehaviour behaviour = other.gameObject.GetComponent<TroopBehaviour> ();
		if (behaviour == null || behaviour.ts == ts) {
			Physics2D.IgnoreCollision (GetComponent<BoxCollider2D> (), other.gameObject.GetComponent<BoxCollider2D> ());
			return;
		}
		speed = 0;
		target = behaviour;
		is_coroutine_running = true;
		StartCoroutine (BeginAttack ());
	}

	void Awake () {
		prev_speed = speed;
	}


	public void TakeDamage (int dmg) {
		health -= dmg;
		if (helt != null) {
			helt.fillAmount = (float)health / (float)max_health;
		}
		if (health <= 0)
			Die ();
		return;
	}

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
			target.TakeDamage (damage);	
		}
		yield return null;

	}

	virtual protected void Die () {
		DestroyObject (gameObject);
	}

}
