using UnityEngine;
using System.Collections;

public class NodeGenerator : MonoBehaviour {
	public GameObject RedNode;
	public GameObject BlueNode;
	public bool isPlaying = false;
	private AudioSource audio;
	private int[,] data = SampleData.data;
	private int preMusicalTime;

	// Use this for initialization
	void Start () {
		this.audio = GetComponent<AudioSource> ();
		startMusic ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Music.IsJustChanged && this.isPlaying && this.preMusicalTime != (int)Music.MusicalTime) {
			//Debug.Log(Music.MusicalTime);
			this.preMusicalTime = (int)Music.MusicalTime;
			for(int i = 0; i < 7; i++){
				switch(data[this.preMusicalTime, i]){
				case 0:
					break;
				case 1:
					if(i % 2 == 0){
						Instantiate(RedNode, new Vector3(i + 1.0F, 10.0F, 0.0F), Quaternion.identity);
					} else {
						Instantiate(BlueNode, new Vector3(i + 1.0F, 10.0F, 0.0F), Quaternion.identity);
					}
					break;
				case 2:
					//TODO Begin Long Tone
					break;
				case 3:
					//TODO End Long Tone
					break;
				case 4:
					this.isPlaying = false;
					break;
				}
			}
		}
	}

	void startMusic(){
		this.isPlaying = true;
		Music.QuantizePlay (audio);
		this.audio.Play ();
	}
}
