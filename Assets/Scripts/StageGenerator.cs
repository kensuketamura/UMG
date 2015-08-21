using UnityEngine;
using System.Collections;

public class StageGenerator : MonoBehaviour {
	public GameObject horizonLine;
	public GameObject touchLine;
	public GameObject destroyArea;
	public GameObject bottom;
	public int nodeNum = 7;

	// Use this for initialization
	void Start () {
		this.horizonLine = Resources.Load<GameObject>("Prefubs/HoriLine");
		this.touchLine = Resources.Load<GameObject>("Prefubs/TouchLine");
		this.destroyArea = Resources.Load<GameObject>("Prefubs/DestroyArea");
		this.bottom = Resources.Load<GameObject>("Prefubs/Bottom");

		for (int i = 0; i <= this.nodeNum; i++) {
			Instantiate(this.horizonLine, new Vector3(0.5F + 1.0F * i, 0, 0), Quaternion.identity);
		}
		Instantiate(this.touchLine, new Vector3(0.5F, 0, 1), Quaternion.identity);
		Instantiate(this.destroyArea, new Vector3(5.0F, -2.0F, 0), Quaternion.identity);
		Instantiate(this.bottom, new Vector3(0, 0, 0), Quaternion.identity);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
