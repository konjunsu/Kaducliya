using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TroopButton : MonoBehaviour {

	public TroopSystem troop_reference;
	public int troop_id;

	void Start () {
		GetComponent<Button> ().onClick.AddListener (delegate { ButtonClick(); });
	}

	void ButtonClick () {
		troop_reference.InstantiateTroop (troop_id);
	}


}
