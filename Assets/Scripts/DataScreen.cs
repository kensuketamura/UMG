using UnityEngine;
using System.Collections;

public class DataScreen : MonoBehaviour {

	public Sprite[] judgeImgs = new Sprite[5];
	private float beginTime = 0;
	private SpriteRenderer JudgeAndCombo;

	// Use this for initialization
	void Start () {
		this.JudgeAndCombo = (GameObject.Find("JudgeAndCombo")).GetComponent<SpriteRenderer>();
		this.JudgeAndCombo.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		this.checkTimeOfJudgeAndCombo ();
	}

	public void screenJudgeAndCombo (Controller.Judge judge){
		this.setImage (judge);
		this.JudgeAndCombo.enabled = true;
		this.beginTime = Music.AudioTimeSec;
	}

	private void setImage(Controller.Judge judge){
		switch (judge) {
		case Controller.Judge.PERFECT:
			this.JudgeAndCombo.sprite = this.judgeImgs[0];
			break;
		case Controller.Judge.GREAT:
			this.JudgeAndCombo.sprite = this.judgeImgs[1];
			break;
		case Controller.Judge.GOOD:
			this.JudgeAndCombo.sprite = this.judgeImgs[2];
			break;
		case Controller.Judge.BAD:
			this.JudgeAndCombo.sprite = this.judgeImgs[3];
			break;
		case Controller.Judge.MISS:
			this.JudgeAndCombo.sprite = this.judgeImgs[4];
			break;
		}
	}

	private void checkTimeOfJudgeAndCombo(){
		if (Music.AudioTimeSec - this.beginTime > 1) {
			this.JudgeAndCombo.enabled = false;
		}
	}
}
