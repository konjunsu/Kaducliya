using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CopperManager : MonoBehaviour {

	public Text copper_text;
	public float copper_rate;
	public AchiBehaviour achieve;
	public uint copper_plus;

	private bool CopperI = false;
	private bool CopperII = false;
	private bool CopperIII = false;

	private IEnumerator ManageCopper () {
		while (true) {
			if (Globals.collect_copper) {
				Globals.copper_count += (int)copper_plus;
				copper_text.text = Globals.copper_count.ToString ();
				if (Globals.copper_count > 1500 && !CopperI) {
					achieve.ShowAchievement (2);
					CopperI = true;
				}
				if (Globals.copper_count > 3000 && !CopperII) {
					achieve.ShowAchievement (3);
					CopperII = true;
				}
				if (Globals.copper_count > 5000 && !CopperIII) {
					achieve.ShowAchievement (4);
					CopperIII = true;
				}
			}
			yield return new WaitForSeconds (copper_rate);
		}
	}

	// Use this for initialization
	void Start () {
		StartCoroutine (ManageCopper ());
	}

}
