using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour {
    //スコアを定義、これをスコアにする。
    private int Score = 0;
    //スコアを表示するテキストを定義
    private GameObject ballscore;

	// Use this for initialization
	void Start () {
        //シーン中のBallScoreTextオブジェクトを取得
        this.ballscore = GameObject.Find("ScoreText");
    }
	
	// Update is called once per frame
	void Update () {
        //スコアの表示
        this.ballscore.GetComponent<Text>().text = "今日の貯金：" + this.Score;
    }

    //衝突時にそれぞれの得点を加算する関数を作成
    void OnCollisionEnter(Collision other){
        if (tag == "SmallStarTag"){
            this.Score += 30;
        }
        if (tag == "SmallCloudTag") {
            this.Score += 80;
        }
        if (tag == "LargeStarTag"){
            this.Score += 10;
        }
        if (tag == "LargeCloudTag"){
            this.Score += 1000;
        }
    }
}
