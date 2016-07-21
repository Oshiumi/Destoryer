using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
	public int score,clearscore=100;
	public bool endFlag=false;
	public GUIText clearText;
	public string nextscene;

	// Use this for initialization
	void Start ()
	{
		score = 0;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (score >= clearscore) {
			endFlag = true;
			clearText.text = "CLEAR\nScore:"+score;
			if (Input.GetMouseButtonDown (0)) {
				Application.LoadLevel (nextscene);

			}

		}
	}
}
