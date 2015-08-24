using UnityEngine;
using System.Collections;

public class Controller : MonoBehaviour {
	public AudioClip[] sounds = new AudioClip[8];
	public KeyCode[] keys = new KeyCode[8];
	public Sprite[] judgeImgs = new Sprite[5];
	public GameObject[,] notes;
	public float judgeLag = 0.1F;
	public float judgeY;
	private AudioSource audioSrc;
	private Music music;

	public enum Judge{
		PERFECT,
		GREAT,
		GOOD,
		BAD,
		MISS,
		NONE
	};

	// Use this for initialization
	void Start () {
		this.audioSrc = this.GetComponent<AudioSource> ();
		this.music = GameObject.Find ("NoteGenerator").GetComponent<Music> ();
		notes = new GameObject[2000, 7];
		this.judgeY = NoteGenerator.noteSpeed * (this.judgeLag / 0.01F);
	}
	
	// Update is called once per frame
	void Update () {
		this.judgeY = NoteGenerator.noteSpeed * (this.judgeLag / 0.01F);
		checkKeyDown ();
	}

	void checkKeyDown(){
		for (int i = 0; i < this.keys.Length; i++) {
			if(Input.GetKeyDown(this.keys[i])){
				this.audioSrc.PlayOneShot(this.sounds[i]);
				GameObject targetNote = this.findTargetNote(i);
				if(targetNote != null){
					this.evalAction(this.judge(targetNote), targetNote);
				}
			}
		}
	}

	GameObject findTargetNote(int num){
		for (int i = 0; i < 16; i++) {
			GameObject suffixNote = this.notes [Music.Near.CurrentMusicalTime + i - 32, num];
			GameObject prefixNote = this.notes [Music.Near.CurrentMusicalTime - i - 32, num];
			if (Music.MusicalTime - Music.Near.CurrentMusicalTime <= 0){
				if (prefixNote != null) {
					return prefixNote;
				}
				if (suffixNote != null) {
					return suffixNote;
				}
			} else {
				if (suffixNote != null) {
					return suffixNote;
				}
				if (prefixNote != null) {
					return prefixNote;
				}
			}
		}
		return null;
	}

	Judge judge(GameObject targetNote){
		float y = targetNote.transform.position.y;
		float diffY = (y > 0)? y : (-y);
		if (diffY <= this.judgeY) {
			return Judge.PERFECT;
		}
		if(diffY <= this.judgeY * 1.5F) {
			return Judge.GREAT;
		}
		if(diffY <= this.judgeY * 2.5F) {
			return Judge.GOOD;
		}
		if(diffY <= this.judgeY * 4.0F) {
			return Judge.BAD;
		}
		if(diffY <= this.judgeY * 5.0F) {
			return Judge.MISS;
		}
		return Judge.NONE;
	}

	void evalAction(Judge judge, GameObject targetNote){
		switch (judge) {
		case Judge.PERFECT:
			Player.addScore(500);
			Player.addCombo();
			Destroy(targetNote);
			break;
		case Judge.GREAT:
			Player.addScore(300);
			Player.addCombo();
			Destroy(targetNote);
			break;
		case Judge.GOOD:
			Player.addScore(100);
			Player.addCombo();
			Destroy(targetNote);
			break;
		case Judge.BAD:
			Destroy(targetNote);
			break;
		case Judge.MISS:
			Destroy(targetNote);
			break;
		case Judge.NONE:
			break;
		}
		Debug.Log (judge);
	}

	public GameObject setNote(GameObject note, int time, int num){
		this.notes [time, num] = note;
		return note;
	}
}
