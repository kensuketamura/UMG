using UnityEngine;
using System.Collections;

public class StageGenerator : MonoBehaviour {
	public GameObject horizonLine;
	public GameObject touchLine;
	public int nodeNum = 7;

	// Use this for initialization
	void Start () {
		this.horizonLine = Resources.Load<GameObject>("Prefubs/HoriLine");
		this.touchLine = Resources.Load<GameObject>("Prefubs/TouchLine");
		for (int i = 0; i <= this.nodeNum; i++) {
			Instantiate(this.horizonLine, new Vector3(0.5F + 1.0F * i, 0, 0), Quaternion.identity);
		}
		Instantiate(this.touchLine, new Vector3(0.5F, 0, 0), Quaternion.identity);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
