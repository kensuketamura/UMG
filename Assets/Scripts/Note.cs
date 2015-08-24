using UnityEngine;
using System.Collections;

public class Note : MonoBehaviour {
	public int number;
	private float speed;
	// Use this for initialization
	void Start () {
		this.speed = NoteGenerator.noteSpeed;
	}
	
	// Update is called once per frame
	void Update () {

	}
	void FixedUpdate () {
		Vector3 pos = this.transform.position;
		this.transform.position = new Vector3 (pos.x, pos.y - this.speed, pos.z);
	}

	void OnCollisionEnter(Collision otherObj) {
		Destroy(gameObject);
	}

	public int setNumber(int num){
		this.number = num;
		return this.number;
	}
}
