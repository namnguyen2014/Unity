using UnityEngine;
using System.Collections;

public class shooting : MonoBehaviour {

	float delayTime = 1;
	public GameObject bulletPrefab;

	// Update is called once per frame
	void Update () {
		delayTime -= Time.deltaTime;
		if(Input.GetKey(KeyCode.Space) && delayTime <= 0)
			{
				shoot();
			delayTime = 1;
			}else
				return;
			
	}
	void shoot()
	{
		Transform shotBullet = Instantiate(bulletPrefab,transform.position, transform.rotation) as Transform;
	}
}
