using UnityEngine;
using System.Collections;

public class NoteGenerator : MonoBehaviour {
	public GameObject RedNode;
	public GameObject BlueNode;
	public bool isPlaying = false;
	public static int samplesPerBeat;
	public static float startY = 30.0F;
	private AudioSource audio;
	private int[,] data = SampleData.data;
	private int preMusicalTime = -1;

	// Use this for initialization
	void Start () {
		this.audio = GetComponent<AudioSource> ();
		samplesPerBeat = (GetComponent<Music> ()).samplesPerBeat_;
		startMusic ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Music.IsJustChanged && this.isPlaying) {
			generateNote();
		}
	}

	void startMusic(){
		this.isPlaying = true;
		Music.QuantizePlay (this.audio);
		//this.audio.Play ();
	}

	void generateNote(){
		if (this.preMusicalTime != (int)Music.MusicalTime) {
			//Debug.Log(Music.MusicTimeUnit);
			this.preMusicalTime = (int)Music.MusicalTime;
			for(int i = 0; i < 7; i++){
				switch(data[this.preMusicalTime, i]){
				case 0:
					break;
				case 1:
					if(i % 2 == 0){
						GameObject note = (GameObject)Instantiate(RedNode, new Vector3(i + 1.0F, startY, 0.0F), Quaternion.identity);
					} else {
						GameObject note = (GameObject)Instantiate(BlueNode, new Vector3(i + 1.0F, startY, 0.0F), Quaternion.identity);
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
}
