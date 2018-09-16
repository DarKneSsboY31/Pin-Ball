using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FripperController : MonoBehaviour {

    //HingeJointコーポネントを入れる
    private HingeJoint myHingeJoint;

    //初期の傾き
    private float defaultAngle = 20f;
    //はじいた時の傾き
    private float flickAngle = -20f;

    // Use this for initialization
    void Start () {

        //HingeJointコンポーネントの取得
        this.myHingeJoint = GetComponent<HingeJoint>();

        //フリッパーの傾きを設定
        SetAngle(this.defaultAngle);

	}
	
	// Update is called once per frame
	void Update () {

        //左矢印キーを押した時、左フリッパーを動かす。
        if (Input.GetKeyDown(KeyCode.LeftArrow) && tag == "LeftFripperTag") {
            SetAngle(this.flickAngle);
        }

        //右矢印キーを押した時、右フリッパーを動かす。
        if (Input.GetKeyDown(KeyCode.RightArrow) && tag == "RightFripperTag") {
            SetAngle(this.flickAngle);
        }

        //矢印キーが離された時、フリッパーをそれぞれ元に戻す。
        if (Input.GetKeyUp(KeyCode.LeftArrow) && tag == "LeftFripperTag") {
            SetAngle(this.defaultAngle);
        }
        if (Input.GetKeyUp(KeyCode.RightArrow) && tag == "RightFripperTag"){
            SetAngle(this.defaultAngle);
        }
        //Touchを定義

        Touch[] myTouches = Input.touches;
        for (int i = 0; i < Input.touchCount; i++) {
        

        //画面左をタップした時、左フリッパーを動かす。
        if (Input.GetTouch(i).position.x < Screen.width * 0.5f && tag == "LeftFripperTag") {
            SetAngle(this.flickAngle);
        }

        //画面右をタップした時、右フリッパーを動かす。
        if (Input.GetTouch(i).position.x > Screen.width * 0.5f && tag == "RightFripperTag") {
            SetAngle(this.flickAngle);
        }

            //指を画面から話した時、フリッパーをそれぞれ戻す。
            if (Input.GetTouch(i).position.x < Screen.width * 0.5f && tag == "LeftFripperTag" &&  Input.GetTouch(i).phase == TouchPhase.Ended) {
            SetAngle(this.defaultAngle);
        }

        if (Input.GetTouch(i).position.x > Screen.width * 0.5f && tag == "RightFripperTag" && Input.GetTouch(i).phase == TouchPhase.Ended)
        {
            SetAngle(this.defaultAngle);
        }
    }

}

    //フリッパーの傾きを設定
    public void SetAngle(float angle) {
        JointSpring jointSpr = this.myHingeJoint.spring;
        jointSpr.targetPosition = angle;
        this.myHingeJoint.spring = jointSpr;
    }
}
