using UnityEngine;
using System.Collections;

public class Cubedivisor : MonoBehaviour {
	// Use this for initialization
	int i,j,k;
	Vector3 cubepos,newcubepos,cubescale,newcubescale,rb1,rb2;
	Rigidbody RB,newRB;
	public float vmlim=2f,scalelim=0.5f,divisor=8f;
	//vmlim:衝撃耐性（のつもり）大きいほど破壊されにくい
	//scalelim:分割のサイズ制限（小さすぎると処理落ち）
	//divisor:分割後ブロックに伝える衝撃の減衰
	//固定値にしてしまってもいいかもしれない
	void Start () {
	}

	// Update is called once per frame
	void Update () {
		//現在のフレームのベクトルをrb1に代入
		RB = GetComponent<Rigidbody> ();
		rb1 = RB.velocity;
		if (Mathf.Abs (rb1.magnitude - rb2.magnitude)>vmlim) {
			//現在のベクトル(rb1)の大きさと1フレーム前のベクトル(rb2)の大きさの差の絶対値がvmlimより大きい
			//元オブジェクトの位置と大きさを呼び出す
			cubepos = this.transform.position;
			cubescale = this.transform.localScale;
			if (cubescale.x >= scalelim || cubescale.y >= scalelim || cubescale.z >= scalelim) {
				//元オブジェクトの大きさがscalelim以上（小さすぎるものは分割しないようにするため調整する必要有り）
				for (i = 0; i < 2; i++) {
					for (j = 0; j < 2; j++) {
						for (k = 0; k < 2; k++) {
							//オブジェクトを生成
							GameObject instance = (GameObject)Instantiate (this.gameObject);
							//分割したオブジェクトの大きさを計算
							newcubescale = instance.transform.localScale / 2f;
							instance.transform.localScale = newcubescale;
							//分割したオブジェクトの位置を計算
							newcubepos = cubepos;
							newcubepos.x -= newcubescale.x * (0.5f - (float)i);
							newcubepos.y += newcubescale.y * (-0.5f + (float)j);
							newcubepos.z -= newcubescale.z * (0.5f - (float)k);
							instance.transform.position = newcubepos;
							//分割したオブジェクトに元オブジェクトにかかっていたベクトルを一部引き継ぐ
							newRB = instance.GetComponent<Rigidbody> ();
							newRB.velocity = rb1 / divisor;
						}
					}
				}
			}
				Destroy (this.gameObject);
		}
		//現在のフレームのベクトルの大きさをrb2に代入
		rb2 = rb1;
	}
}
