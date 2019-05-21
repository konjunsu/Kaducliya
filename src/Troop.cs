using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Troop", menuName = "Troop")]
public class Troop : ScriptableObject {

	public Sprite troop_sprite;
	public int troop_cost;
	public GameObject troop_prefab;
	public float training_time;

}
