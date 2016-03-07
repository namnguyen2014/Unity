using UnityEngine;
using System.Collections;

public class bullet : MonoBehaviour {
	float speed = 1.5f;
	float RotSpeed = 3f;
	Transform trans_Enemy;

	void Start()
	{
		trans_Enemy = GameObject.FindWithTag("enemyPoint").transform;
	}
	// Update is called once per frame
	void Update () {

		float positionX = trans_Enemy.position.x - transform.position.x;
		float positionY = trans_Enemy.position.y - transform.position.y;

		gameObject.transform.Translate(new Vector2(positionX,positionY)* speed * Time.deltaTime);
	}
	void OnTriggerEnter2D (Collider2D endPoint)
	{
		// destroy bullet
		Destroy(gameObject);
	}

}
