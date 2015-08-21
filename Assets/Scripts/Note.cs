using UnityEngine;
using System.Collections;

public class Note : MonoBehaviour {
	public int number;
	private float speed;
	// Use this for initialization
	void Start () {
		this.speed = (NoteGenerator.startY / (NoteGenerator.samplesPerBeat * 4 * (1.0F / 44100.0F))) * 0.01F;
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
}
