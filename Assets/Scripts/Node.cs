using UnityEngine;
using System.Collections;

public class Node : MonoBehaviour {
	public int number;
	private Rigidbody rigidbody;
	private float speed;
	private float start;
	// Use this for initialization
	void Start () {
//		this.rigidbody = GetComponent<Rigidbody> ();
//		this.rigidbody.AddForce (new Vector3 (0, -500.0F, 0));
		this.start = Music.MusicalTimeBar;
	}
	
	// Update is called once per frame
	void Update () {

	}
	void FixedUpdate () {
		Vector3 pos = this.transform.position;
		if (Music.MusicalTimeBar - start < 0) {
			this.transform.position = new Vector3 (pos.x, 10.0F - (float)(Music.MusicalTimeBar + start) * 10.0F, pos.z);
		} else {
			this.transform.position = new Vector3 (pos.x, 10.0F - (float)(Music.MusicalTimeBar - start) * 10.0F, pos.z);
		}
		Debug.Log (Music.MusicalTimeBar - start);
	}

	void OnCollisionEnter(Collision otherObj) {
		Destroy(gameObject,.1f);
	}
}
