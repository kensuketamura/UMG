using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	public int combo = 0;
	public int score = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void addCombo(int c = 1){
		this.combo += c;
	}

	public void addScore(int s){
		this.score += s;
	}

	public void missCombo(){
		this.combo = 0;
	}
}
