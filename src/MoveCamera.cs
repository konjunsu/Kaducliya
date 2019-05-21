using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour {

	private GameObject cam;
	public float speed = 1.0f;

	// Use this for initialization
	void Start () {
		cam = Camera.main.gameObject;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.D) && cam.transform.position.x < Globals.dist_init + Globals.max_dist) {
			cam.transform.Translate (new Vector3 (speed, 0, 0));
		}
		if (Input.GetKey (KeyCode.A) && cam.transform.position.x > Globals.dist_init) {
			cam.transform.Translate (new Vector3 (-speed, 0, 0));
		}
	}
}
