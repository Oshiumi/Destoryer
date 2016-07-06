using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {


	// Use this for initialization
	void Start ()
    {
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKey("w")) {//Input.GetKey()でキー入力時の操作
            //transformクラスにforward,right,upの3つのプロパティ
            //forwardは前に(この場合は0.1だけ前に進む)
            transform.Translate(transform.forward * 0.1f);
        }if (Input.GetKey("s")){
            //後退する場合はbackはないため、マイナスをつける
            transform.Translate(transform.forward * -0.1f);
        }if (Input.GetKey("a")){
            //rightは右に。leftがないため、マイナスをつける
            transform.Translate(transform.right * -0.1f);
        }if (Input.GetKey("d")){
            //右に0.1進む
            transform.Translate(transform.right * 0.1f);
        }
	}
}
