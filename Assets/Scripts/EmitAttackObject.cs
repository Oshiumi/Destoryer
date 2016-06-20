using UnityEngine;
using System.Collections;

public class EmitAttackObject : MonoBehaviour {

  public GameObject attackObjectPrefab;
  public float initialSpeed;

  // Use this for initialization
  void Start () {

  }

  // Update is called once per frame
  void Update () {
    if ( Input.GetMouseButtonDown(0) ) {
      // attackObject を複製
      GameObject attackObject = (GameObject)Instantiate (attackObjectPrefab, transform.position, transform.rotation);
      // 左クリックされた座標から単位ベクトルを計算
      var screenMousePosition = Input.mousePosition;
      screenMousePosition.z = 10f;
      // スクリーン座標からワールド座標への変換
      Vector3 direction = Camera.main.ScreenToWorldPoint (screenMousePosition);
      // スクリーン座標にはzがないため追加
      // direction.z = target.transform.position.z - transform.position.z;
      direction.z = -transform.position.z;
      // attackObject に初速を追加
      attackObject.GetComponent<Rigidbody> ().velocity = direction * initialSpeed;
    }
  }
}
