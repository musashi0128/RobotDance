using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotGroup : MonoBehaviour {

	List<RobotScript> robots = new List<RobotScript>();

	// new RobotGropuが実行された時、自動的に作成される
	public RobotGroup(GameObject prefab, float px, float py){

		for (int x = 0; x < 3; x++) {
			for (int y=0;y<3; y++){

				// 一度変数に入れてプレハブの位置をみる
				Vector3 p = Camera.main.ViewportToWorldPoint (new Vector3(px+0.1f * x, py + 0.13f * y, 0f));
				p.z = 0f;

				// コンストラクタを作る 1,どれを 2,どの場所に 3,どんな角度に
				GameObject obj = Object.Instantiate(prefab, p, Quaternion.identity);

				robots.Add (obj.GetComponent<RobotScript> ());
			}
		}
	}

	public void MotionAll(RobotMotion motion){
		foreach (var r in robots) {
			r.AddMotion (new RobotMotion(motion));
		}
	}

	public void MotionRandom(RobotMotion[] motions, List<int> selected){
		foreach (var r in robots) {
			int sel = Random.Range (0, motions.Length);
			r.AddMotion (new RobotMotion(motions[sel]));

			// どちらの変数(selected)が選択されているか決まる
			selected [sel]++;
		}
	}
}
