using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	public static int combo = 0;
	public static int score = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public static void addCombo(int c = 1){
		combo += c;
	}

	public static void addScore(int s){
		score += s;
	}
}
