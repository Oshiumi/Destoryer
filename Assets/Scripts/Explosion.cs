using UnityEngine;
using System.Collections;

public class Explosion : MonoBehaviour
{
	public Transform explosion;

	// Use this for initialization
	void Start ()
	{
	}
	
	// Update is called once per frame
	void Update ()
	{
	}
		
	void OnCollisionEnter (Collision collision)
	{
		if (collision.gameObject.tag == "AttackObj") {
			Instantiate (explosion, collision.transform.position, Quaternion.identity);
		}
	}
}