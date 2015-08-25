using UnityEngine;
using System.Collections;

public class NoteGenerator : MonoBehaviour {
	public GameObject RedNode;
	public GameObject BlueNode;
	public bool isPlaying = false;
	public int samplesPerBeat;
	public float startY = 30.0F;

	public static float noteSpeed; 

	private AudioSource audio;
	private Controller controller;
	private int[,] data = SampleData.data;
	private int preMusicalTime = -1;

	// Use this for initialization
	void Start () {
		this.audio = GetComponent<AudioSource> ();
		this.controller = (GameObject.Find ("Controller")).GetComponent<Controller> ();

		this.samplesPerBeat = (GetComponent<Music> ()).samplesPerBeat_;
		noteSpeed = (startY / (samplesPerBeat * 4 * (1.0F / 44100.0F))) * 0.01F;
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
					GameObject note = null;
					if(i % 2 == 0){
						note = (GameObject)Instantiate(RedNode, new Vector3(i + 1.0F, startY, 0.0F), Quaternion.identity);
					} else {
						note = (GameObject)Instantiate(BlueNode, new Vector3(i + 1.0F, startY, 0.0F), Quaternion.identity);
					}
					Note n = (note.GetComponent<Note>());
					n.setNumber(i);
					n.setController(this.controller);
					this.controller.setNote(note, this.preMusicalTime, i);
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
