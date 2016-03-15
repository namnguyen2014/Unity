using UnityEngine;
using System.Collections;

public class NinjaManagement : MonoBehaviour {

	private Rigidbody2D rb2D;
	private Animator myAnimator;

	private float movementSpeed = 10;
	private bool isChangeSpriteDirection = true;
	private bool isAttack = false;

	// Use this for initialization
	private void Start () {
		rb2D = GetComponent<Rigidbody2D>();
		myAnimator = GetComponent<Animator>();
	}

	// Update is called once per frame
	private void Update()
	{
		InputManagement();
	}

	private void FixedUpdate () {
		float h = Input.GetAxis("Horizontal");
		float v = Input.GetAxis("Vertical");

		NinjaRun(h);
		NinjaJump(v);
		NinjaAttack();
		isAttack = false;

		ChangeSpriteDirection(h);
	}

	// Action: RUN (theo truc X)
	private void NinjaRun (float h)
	{
		if(h != 0)
		{
			Vector2 horizontal = new Vector2(h * movementSpeed, 0);
			rb2D.velocity = horizontal;
			myAnimator.SetFloat("Speed", Mathf.Abs(h));
		}
	}

	// Action: JUMP (theo truc Y)
	private void NinjaJump(float v)
	{
		if(v != 0)
		{
			Vector2 vertical = new Vector2(0, v * movementSpeed);
			rb2D.velocity = vertical;
			myAnimator.SetFloat("Height", Mathf.Abs(v));
		}
	}

	// Action: ATTACK
	private void NinjaAttack()
	{
			if(isAttack)
			{
				myAnimator.SetTrigger("Attack");
			}
	}

	// Xu ly: Di chuyen qua trai - Quay mat sang trai
	private void ChangeSpriteDirection(float h)
	{
		if(h > 0 && !isChangeSpriteDirection || h < 0 && isChangeSpriteDirection)
		{
			isChangeSpriteDirection = !isChangeSpriteDirection;
			Vector3 scaleByX = transform.localScale;
			scaleByX.x *= -1;
			transform.localScale = scaleByX;
		}
	}

	// Xu ly: Quan ly Input
	private void InputManagement()
	{
		if(Input.GetKeyDown(KeyCode.Space))
		{
			isAttack = true;
		}
	}
}
