using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;

public class Globals {

	public static int copper_count = 200;
	public static bool collect_copper = true;
	public static bool spawn_troops = true;
	public static float duration = 0.01f;
	public static float max_dist = 30.0f;
	public static float dist_init = -20.0f;
	public static float achi_wait = 2.5f;
	public static float achi_check = 0.2f;

	public static string achisave = "achidata.dat";
	public static Stopwatch timer;

}
