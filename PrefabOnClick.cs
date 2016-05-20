using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PrefabOnClick : MonoBehaviour {
	public Sprite img_1;
	public Sprite img_2;
	public Image imgCell;
	public CellManagement cell;

	private float delayTime = 5;

	public void Start()
	{
		imgCell = GetComponent<Image>(); 
	}

	public void Update()
	{
		if(delayTime > 0)
		{
			delayTime -= Time.deltaTime;
		}

	}

	public void OnMouseDown()
	{
		ChangeSprite();
	}

	public void ChangeSprite()
	{
			if(imgCell.sprite == img_1)
			{
				imgCell.sprite = img_2;

			}
			else 
			{
				imgCell.sprite = img_1;
			}
	}
}
