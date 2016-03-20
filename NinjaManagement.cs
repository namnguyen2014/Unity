using UnityEngine;
using System.Collections;

public class NinjaManagement : MonoBehaviour {

	private Rigidbody2D rb2D;
	private Animator myAnimator;

	private float movementSpeed = 10;

	private bool isChangeSpriteDirection = true;
	private bool isAttack = false;
	private bool isOnGround = true;

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
		if(isOnGround = true)
		{
			NinjaMovement(h,v);
			Animating(h,v);
			isOnGround = false;
		}

		NinjaAttack();
		isAttack = false;

		ChangeSpriteDirection(h);
	}

	// Action: RUN and JUMP
	private void NinjaMovement(float h, float v)
	{
		if(h != 0 || v != 0)
		{
			Vector2 movement = new Vector2(h * movementSpeed, v * movementSpeed);
			rb2D.velocity = movement;
		}
	}

	// Animation
	private void Animating(float h, float v)
	{
		myAnimator.SetFloat("Speed", Mathf.Abs(h));
		myAnimator.SetFloat("Height", Mathf.Abs(v));
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

	private void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.tag == "Ground") 
		{
			isOnGround = true;
		}
	}
}
