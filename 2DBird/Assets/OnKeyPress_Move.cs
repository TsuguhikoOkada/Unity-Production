using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// キーを押すと、移動する 
public class OnKeyPress_Move : MonoBehaviour {

	public float speed = 2; // スピード：Inspectorで指定

	float vx = 0;
	float vy = 0;
	bool leftFlag = false;
	Rigidbody2D rbody;

	void Start () { // 最初に行う
		// 重力を0にして、衝突時に回転させない
		rbody = GetComponent<Rigidbody2D>();
		// rbody.gravityScale = 0;
		rbody.constraints = RigidbodyConstraints2D.FreezeRotation;
	}

	void Update () { // ずっと行う
		vx = 0;
		vy = 0;
		if(Input.GetKey("right")) { // もし、右キーが押されたら
			vx = speed; // 右に進む移動量を入れる
			leftFlag = false;
		}
		if(Input.GetKey("left")) { // もし、左キーが押されたら
			vx = -speed; // 左に進む移動量を入れる
			leftFlag = true;
		}
		if(Input.GetKey("up")) { // もし、上キーが押されたら
			vy = speed; // 上に進む移動量を入れる
		}
		if(Input.GetKey("down")) { // もし、下キーが押されたら
			vy = -speed; // 下に進む移動量を入れる
		}
	}
	void FixedUpdate() { // ずっと行う（一定時間ごとに）
		// 移動する
		rbody.velocity = new Vector2(vx, vy); 
		// 左右の向きを変える
        this.GetComponent<SpriteRenderer>().flipX = leftFlag;
	}
}
