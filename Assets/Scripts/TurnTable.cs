using UnityEngine;
using System.Collections;

public class TurnTable : MonoBehaviour {

	private float angle = 2;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.Rotate (new Vector3 (0, this.angle, 0));
	}

	public void changeAngle(){
		this.angle = 0 - this.angle;
	}
}
