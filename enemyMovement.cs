using UnityEngine;
using System.Collections;

public class enemyMovement : MonoBehaviour {
	float timeofMove = 1;
	float speedofEnemy = 1.5f;
	
	// Update is called once per frame
	void Update () {
		timeofMove -= Time.deltaTime;
		if(timeofMove <= 0)
		{
			speedofEnemy = -speedofEnemy;
			timeofMove = 1;
		}
		gameObject.transform.Translate(new Vector2 (0, 1 * speedofEnemy * Time.deltaTime));
	}
}
