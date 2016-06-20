using UnityEngine;
using System.Collections;

public class PointGet : MonoBehaviour
{
	public GameManager gm;
	public GameObject gameManager;

	// Use this for initialization
	void Start ()
	{
		gm = gameManager.GetComponent<GameManager> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
	}

	void OnCollisionEnter (Collision collision)
	{
		if (collision.gameObject.tag == "AttackObj")
			gm.score += 100;
	}
}
