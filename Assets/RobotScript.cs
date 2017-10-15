using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotScript : MonoBehaviour {

	public bool ManualDance = false;

	// 連想配列
	Dictionary<string, Sprite> pose = new Dictionary<string, Sprite>(){
		{"Normal", null},
		{"Right",null},
		{"Left",null},
		{"Both",null}
	};

	List<RobotMotion>motions = new List<RobotMotion>();

	// Use this for initialization
	void Start () {
		foreach(var key in new List<string>(pose.Keys)) {
			// Robot + _Keysの名前を読み込む
			Texture2D tex = (Texture2D)Resources.Load("Robot-"+key);
			// poseのkeyに入れてく
			pose[key] = Sprite.Create(tex, new Rect(0,0, tex.width, tex.height), new Vector2(0.5f, 0.5f));
		}
	}

	// 保存されたMotionを追加していく
	public void AddMotion(RobotMotion m){
		motions.Add (m);
	}

	public void Pose(string p){
		GetComponent<SpriteRenderer> ().sprite = pose [p];
	}
	
	// Update is called once per frame
	void Update () {

		if (motions.Count > 0) {
			bool finished = motions [0].Animate (this, Time.deltaTime);
			if (finished) {
				motions.RemoveAt (0);
			}
		}

		// マウスに反応するものしないものを条件で指定
		if (ManualDance == true) {

			if (Input.GetMouseButton (0) && Input.GetMouseButton (1)) {
				Pose ("Both");

			} else if (Input.GetMouseButton (0)) {
				Pose ("Left");
				
			} else if (Input.GetMouseButton (1)) {
				Pose ("Right");
				
			} else {
				Pose ("Normal");
			}

		}
	}
}
