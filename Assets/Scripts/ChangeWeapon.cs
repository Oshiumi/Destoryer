using UnityEngine;
using System.Collections;

public class ChangeWeapon : MonoBehaviour {

    public GameObject[] weapons;
    private int index;

    // Use this for initialization
    void Start () {
        // ゲーム開始時、0番目の武器を自動装備
        GameObject obj = (GameObject)Instantiate(weapons[0], transform.position, transform.rotation);
        // player -> equipment -> weapon の親子関係を設定
        GameObject equip = new GameObject("equipment");
        obj.transform.parent  = equip.transform;
        equip.transform.parent = transform;
    }
	
	// Update is called once per frame
	void Update () {
        // ホイール入力を取得
	    float input = Input.GetAxis("Mouse ScrollWheel");
        // キーボード入力の取得
        int num = keyNumber();

        if(input < 0) {
            index = (index + 1) % weapons.Length;
            Change(index);
        } else if(input > 0) {
            index = (weapons.Length + index - 1) % weapons.Length;
            Change(index);
        } else if(0 < num && num <= weapons.Length) {
            index = num - 1;
            Change(index);
        }
    }

    void Change(int idx) {
        // 今持ってる武器を削除
        Transform equip = transform.FindChild("equipment");
        Destroy(equip.GetChild(0).gameObject);
        // idx 番目の武器を持たせる
        GameObject obj = (GameObject)Instantiate(weapons[idx], transform.position, transform.rotation);
        obj.transform.parent = equip.transform;
    }

    int keyNumber() {
        if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Keypad1)) return 1;
        else if (Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Keypad2)) return 2;
        else if (Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Keypad3)) return 3;
        else if (Input.GetKeyDown(KeyCode.Alpha4) || Input.GetKeyDown(KeyCode.Keypad4)) return 4;
        else if (Input.GetKeyDown(KeyCode.Alpha5) || Input.GetKeyDown(KeyCode.Keypad5)) return 5;
        else if (Input.GetKeyDown(KeyCode.Alpha6) || Input.GetKeyDown(KeyCode.Keypad6)) return 6;
        else if (Input.GetKeyDown(KeyCode.Alpha7) || Input.GetKeyDown(KeyCode.Keypad7)) return 7;
        else if (Input.GetKeyDown(KeyCode.Alpha8) || Input.GetKeyDown(KeyCode.Keypad8)) return 8;
        else if (Input.GetKeyDown(KeyCode.Alpha9) || Input.GetKeyDown(KeyCode.Keypad9)) return 9;
        else return 0;
    }
}
