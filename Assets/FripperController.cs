using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FripperController : MonoBehaviour
{

    //LeftfingerIdと、RightfingerIdを定義。fingerId = -1は、fingerId無しの意味
    int LeftfingerId = -1;
    int RightfingerId = -1;

    //HingeJointコーポネントを入れる
    private HingeJoint myHingeJoint;

    //初期の傾き
    private float defaultAngle = 20f;
    //はじいた時の傾き
    private float flickAngle = -20f;

    // Use this for initialization
    void Start()
    {

        //HingeJointコンポーネントの取得
        this.myHingeJoint = GetComponent<HingeJoint>();

        //フリッパーの傾きを設定
        SetAngle(this.defaultAngle);

    }

    // Update is called once per frame
    void Update()
    {

        //左矢印キーを押した時、左フリッパーを動かす。
        if (Input.GetKeyDown(KeyCode.LeftArrow) && tag == "LeftFripperTag")
        {
            SetAngle(this.flickAngle);
        }

        //右矢印キーを押した時、右フリッパーを動かす。
        if (Input.GetKeyDown(KeyCode.RightArrow) && tag == "RightFripperTag")
        {
            SetAngle(this.flickAngle);
        }

        //矢印キーが離された時、フリッパーをそれぞれ元に戻す。
        if (Input.GetKeyUp(KeyCode.LeftArrow) && tag == "LeftFripperTag")
        {
            SetAngle(this.defaultAngle);
        }
        if (Input.GetKeyUp(KeyCode.RightArrow) && tag == "RightFripperTag")
        {
            SetAngle(this.defaultAngle);
        }

        //Touchでフリッパーが作動するようにする。
        Touch[] touches = Input.touches;
        for (int i = 0; i < Input.touchCount; i++)
        {

            //画面左をタップした時、左フリッパーを動かす。
            if (touches[i].position.x < Screen.width * 0.5f && tag == "LeftFripperTag")
            {
                SetAngle(this.flickAngle);
            }
            //画面右をタップした時、右フリッパーを動かす。
            if (touches[i].position.x > Screen.width * 0.5f && tag == "RightFripperTag")
            {
                SetAngle(this.flickAngle);
            }

            //指を画面から離した時、フリッパーをそれぞれ戻す。
            if (touches[i].fingerId == 0 && tag == "LeftFripperTag" && Input.GetTouch(i).phase == TouchPhase.Ended)
            {
                LeftfingerId = 0; if (LeftfingerId == 0)
                {
                    SetAngle(this.defaultAngle);
                }
            }
            else if (touches[i].fingerId == 1 && tag == "LeftFripperTag" && Input.GetTouch(i).phase == TouchPhase.Ended)
            {
                LeftfingerId = 0; if (LeftfingerId == 0)
                {
                    SetAngle(this.defaultAngle);
                }
            }
            if (touches[i].fingerId == 0 && tag == "RightFripperTag" && Input.GetTouch(i).phase == TouchPhase.Ended)
            {
                RightfingerId = 0; if (RightfingerId == 0)
                {
                    SetAngle(this.defaultAngle);
                }
            }
            else if (touches[i].fingerId == 1 && tag == "RightFripperTag" && Input.GetTouch(i).phase == TouchPhase.Ended)
            {
                RightfingerId = 0; if (RightfingerId == 0)
                {
                    SetAngle(this.defaultAngle);
                }

            }
        }
    }
    //フリッパーの傾きを設定
    void SetAngle(float angle)
    {
        JointSpring jointSpr = this.myHingeJoint.spring;
        jointSpr.targetPosition = angle;
        this.myHingeJoint.spring = jointSpr;
    }
}