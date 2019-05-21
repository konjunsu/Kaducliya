using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy Troop", menuName = "Enemy Troop")]
public class EnemyTroop : ScriptableObject {

	public GameObject troop_object;
	public int spawn_probability;

}
