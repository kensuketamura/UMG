using UnityEngine;
using System.Collections;

public class Cotroller : MonoBehaviour {
	public AudioClip[] sounds = new AudioClip[8];
	public KeyCode[] keys = new KeyCode[8];
	private AudioSource audioSrc;

	// Use this for initialization
	void Start () {
		this.audioSrc = this.GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		checkKeyDown ();
	}

	void checkKeyDown(){
		for (int i = 0; i < this.keys.Length; i++) {
			if(Input.GetKeyDown(this.keys[i])){
				this.audioSrc.PlayOneShot(this.sounds[i]);
			}
		}
	}
}
