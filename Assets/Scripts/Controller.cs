using UnityEngine;
using System.Collections;

public class Controller : MonoBehaviour {
	public int playerNum = 0;
	public AudioClip[] sounds = new AudioClip[8];
	public KeyCode[] keys = new KeyCode[8];
	public GameObject[,] notes;
	public float judgeLag = 0.1F;
	public float judgeY;
	public DataScreen screen;
	public Player player;
	public TurnTable ttable;
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
		this.player = GameObject.Find ("Player1").GetComponent<Player> ();
		notes = new GameObject[2000, 8];
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
				if(i == this.keys.Length - 1){
					ttable.changeAngle();
				}
			}
		}
	}

	private GameObject findTargetNote(int num){
		for (int i = 0; i < 16; i++) {
			if(Music.Near.CurrentMusicalTime >= 32){
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
		}
		return null;
	}

	private Judge judge(GameObject targetNote){
		float y = targetNote.transform.position.y;
		float diffY = (y > 0)? y : (-y);
		if (diffY <= this.judgeY) {
			return Judge.PERFECT;
		}
		if(diffY <= this.judgeY * 2.5F) {
			return Judge.GREAT;
		}
		if(diffY <= this.judgeY * 4.0F) {
			return Judge.GOOD;
		}
		if(diffY <= this.judgeY * 5.0F) {
			return Judge.BAD;
		}
		if(diffY <= this.judgeY * 6.0F) {
			return Judge.MISS;
		}
		return Judge.NONE;
	}

	private void evalAction(Judge judge, GameObject targetNote){
		switch (judge) {
		case Judge.PERFECT:
			this.player.addScore(500);
			this.player.addCombo();
			Destroy(targetNote);
			break;
		case Judge.GREAT:
			this.player.addScore(300);
			this.player.addCombo();
			Destroy(targetNote);
			break;
		case Judge.GOOD:
			this.player.addScore(100);
			this.player.addCombo();
			Destroy(targetNote);
			break;
		case Judge.BAD:
			this.player.missCombo();
			Destroy(targetNote);
			break;
		case Judge.MISS:
			this.player.missCombo();
			Destroy(targetNote);
			break;
		case Judge.NONE:
			break;
		}
		this.screen.screenJudgeAndCombo(judge);
		//Debug.Log (judge);
	}

	public GameObject setNote(GameObject note, int time, int num){
		this.notes [time, num] = note;
		return note;
	}

	public void onDestroyNote(){
		this.player.missCombo();
		this.screen.screenJudgeAndCombo(Judge.MISS);
	}

}
