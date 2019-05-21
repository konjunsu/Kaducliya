using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class AchievementLocator {
	int achid;
	bool iscomp;
}

public class AchievementData : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void WriteAchievementsToFile (AchievementLocator[] achs, string file) {
		string json_content = JsonUtility.ToJson (achs);
		File.WriteAllText (Globals.achisave, json_content);
	}

	AchievementLocator[] ReadAchievementFromFile () {
		AchievementLocator[] data;
		string filedata = File.ReadAllText (Globals.achisave);
		data = JsonUtility.FromJson<AchievementLocator[]> (filedata);
		return data;
	}
}
