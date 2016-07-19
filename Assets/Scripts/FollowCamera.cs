using UnityEngine;
using System.Collections;

public class FollowCamera : MonoBehaviour {

	public float distance = 5.0f;
	public float horizontalAngle = 0.0f;
	public float rotAngle = 180.0f; // 画面の横幅分カーソルを移動させたとき何度回転するか.
	public float verticalAngle = 10.0f;
	public Transform lookTarget;
	public Vector3 offset = Vector3.zero;
	private Vector2 prevPosition = Vector2.zero;
	private bool dragging = false;
	private Vector2 dragStartPosition = Vector2.zero;
	private Vector2 delta = Vector2.zero;


	void CheckDragging(){
		// ドラッグの開始
		if(Input.GetMouseButtonDown(0)){
			dragStartPosition = Input.mousePosition;
		}
		// ドラッグ中か
		// 画面幅の1割以上動いたらドラッグとする
		if(Input.GetMouseButton(0)){
			if (Vector2.Distance(dragStartPosition,Input.mousePosition) >= (Screen.width * 0.1f))
				dragging = true;
		}
		// ドラッグが終了したか
		if(!Input.GetMouseButtonUp(0) && !Input.GetMouseButton(0))
			dragging = false;
	}
 
	// Update is called once per frame
	void LateUpdate () {
		CheckDragging();
		Debug.Log(dragging);

		// ドラッグ入力でカメラのアングルを更新する.
		if(dragging){
			float anglePerPixel = rotAngle / (float)Screen.width;
			delta = (Vector2)Input.mousePosition - prevPosition;
			horizontalAngle += delta.x * anglePerPixel;
			horizontalAngle = Mathf.Repeat(horizontalAngle,360.0f);
			verticalAngle -= delta.y * anglePerPixel;
			verticalAngle = Mathf.Clamp(verticalAngle,-60.0f,60.0f);
		}else{
			delta = Vector2.zero;
		}
		prevPosition = (Vector2)Input.mousePosition;

		// カメラを位置と回転を更新する.
		if (lookTarget != null) {
			Vector3 lookPosition = lookTarget.position + offset;
			// 注視対象からの相対位置を求める.
			Vector3 relativePos = Quaternion.Euler(verticalAngle,horizontalAngle,0) *  new Vector3(0,0,-distance);
			
			// 注視対象の位置にオフセット加算した位置に移動させる.
			transform.position = lookPosition + relativePos ;
			
			// 注視対象を注視させる.
			transform.LookAt(lookPosition);
			
			// 障害物を避ける.
			RaycastHit hitInfo;
			if (Physics.Linecast(lookPosition,transform.position,out hitInfo,1<<LayerMask.NameToLayer("Ground")))
				transform.position = hitInfo.point;
		}

		// targetのrotationとカメラのrotationを一致させる．
		lookTarget.right = this.transform.right;
	}
}
