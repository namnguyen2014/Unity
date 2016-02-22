using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	Rigidbody2D rb2D;
	Animator animator;
	float speed = 5f;
	bool isBack = true;

	void Start () 
	{
		rb2D = GetComponent<Rigidbody2D>();
		animator = GetComponent<Animator>();
	}

	void FixedUpdate () 
	{
		float h = Input.GetAxis("Horizontal");
		float v = Input.GetAxis("Vertical");
		Move(h,v);
		Animating(h,v);
	}

	void Move(float h, float v)
	{
		if(h != 0 || v != 0)
		{
			Vector2 movement = new Vector2(h*speed, v*speed);
			rb2D.velocity = movement;
			if(h > 0 && !isBack)
			{
				ChangeAnimation();
			}
			else if(h < 0 && isBack)
			{
				ChangeAnimation();
			}
		}
	}

	void Animating(float h, float v)
	{
		bool isRun = h > 0.1f;
		animator.SetFloat("Speed", Mathf.Abs(h));

		bool isJump = v > 0.1f;
		animator.SetFloat("Velocity", Mathf.Abs(v));
	}

	void ChangeAnimation ()
	{
		isBack = !isBack;
		Vector3 scale = transform.localScale;
		scale.x *= -1;
		transform.localScale = scale;
	}
}
