using UnityEngine;
using System.Collections;

public class AttackObject : MonoBehaviour {

  public float lifetime = 1.5f;
  public int yBoundary = -5; // y座標の境界値


  // Use this for initialization
  void Start () {

  }

  // Update is called once per frame
  void Update () {
    // 特に衝突しなかった場合、境界条件を過ぎたら消滅
    if ( transform.position.y < yBoundary ) {
      Destroy(this.gameObject);  
    }
  }

  void OnCollisionEnter(Collision otherObj) {
    // 何かしらに衝突した場合 lifetime 時間後に消滅
    Destroy(this.gameObject, lifetime);
  }
}
