using UnityEngine;
using System.Collections;

public class MoveLandBack : MonoBehaviour {
	 float indicator = 0.05f;
	void Update()
	{
		this.transform.Translate(Vector2.right * indicator);
	}
	void OnTriggerEnter2D(Collider2D coll)
	{
		if (coll.gameObject.tag == "Obs")
		{
			indicator = -indicator;
		}
	}

}