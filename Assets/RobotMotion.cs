using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotMotion {

	Action<RobotScript, float>animation;
	float duration;
	float pastTime = 0;

	// コンストラクタ
	public RobotMotion(RobotMotion src) : this(src.animation, src.duration){
		
	}

	public RobotMotion(Action<RobotScript, float> animation, float duration){

		// 上の変数 animation, durationにコンストラクタのanimation, durationを入れる
		this.animation = animation;
		this.duration = duration;
	}

	public bool Animate(RobotScript robot, float deltaTime){

		// スタート時刻から何秒経ったかを知る
		pastTime += deltaTime;
		animation (robot, pastTime/duration);

		// 条件に一致した場合true
		return pastTime >= duration;
	}


}
