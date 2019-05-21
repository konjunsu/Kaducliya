using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Achievement", menuName = "Achievement")]
public class Achievement : ScriptableObject {
	public Sprite achi_sprite;
	public string achi_name;
	public string achi_desc;
}
