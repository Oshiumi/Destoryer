using UnityEngine;
using System.Collections;

public class AttackObject : MonoBehaviour {

  public float lifetime = 1.5f;

  // Use this for initialization
  void Start () {

  }

  // Update is called once per frame
  void Update () {

  }

  void OnCollisionEnter(Collision otherObj) {
    // 何かしらに衝突した場合 lifetime 時間後に消滅
    Destroy(this.gameObject, lifetime);
  }
}
