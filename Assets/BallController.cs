using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour {

    //スコアを定義、これをスコアにする。
    public int Score = 0;
    //スコアを表示するテキストを定義
    private GameObject ballscore;

    //ボールが見える可能性のあるｚ軸の最大値
    private float visiblePosZ = -6.5f;
    //ゲームオーバーを表示するテキスト
    private GameObject gameoverText;

    // Use this for initialization
    void Start () {

        //シーン中のBallScoreTextオブジェクトを取得
        this.ballscore = GameObject.Find("ScoreText");

        //シーン中のGameOverTextオブジェクトを取得
        this.gameoverText = GameObject.Find("GameOverText");
        
	}
	
	// Update is called once per frame
	void Update () {

        //スコアの表示
        this.ballscore.GetComponent<Text>().text = "Score：" + this.Score;

        //ボールが画面外に出た場合
        if (this.transform.position.z < this.visiblePosZ) {
            //gameoverTextにゲームオーバーを表示
            this.gameoverText.GetComponent<Text>().text = "Game Over";
        }
	}
    //衝突時に呼ばれる関数
    void OnCollisionEnter(Collision collision)
    {
        //当たった時に特定の点数を入れる
        if (collision.gameObject.tag == "SmallStarTag") {
            Score += 30;
        }
        if (collision.gameObject.tag == "LargeStarTag") {
            Score += 10;
        }
        if(collision.gameObject.tag == "SmallCloudTag"){
            Score += 80;
        }
        if (collision.gameObject.tag == "LargeCloudTag") {
            Score += 10000;
        }
    }

}
