using UnityEngine;
using System.Collections;

public class EmitAttackObject : MonoBehaviour {

  public GameObject attackObjectPrefab;
  public float initialSpeed;        // 攻撃オブジェクトの発射速度
  public float raycastMax = 10000.0f; // 射程距離

  // Use this for initialization
  void Start () {

  }

  // Update is called once per frame
  void Update () {
    if ( Input.GetMouseButtonDown(0) ) {
      // クリックされた位置へRayを飛ばす
      Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
      RaycastHit hit;
      if ( Physics.Raycast(ray, out hit, raycastMax) ) {
        // attackObject を複製
        GameObject attackObject = (GameObject)Instantiate(attackObjectPrefab, transform.position, transform.rotation);
        // *** 要検証 *** 攻撃オブジェクトの発射方向を計算
        Vector3 direction = hit.point - transform.position;
        // attackObject に初速を追加
        attackObject.GetComponent<Rigidbody> ().velocity = direction * initialSpeed;
      }
    }
  }
}
