using UnityEngine;
using System.Collections.Generic;

public class CellManagement : MonoBehaviour {

	public GameObject cellPrefab;
	public Transform rootPanel;

	public Sprite[] imgArray;
	private List<PrefabOnClick> lstController = new List<PrefabOnClick>();

	void Start () {
		for(int i = 0; i < 16; i++)
		{
			GameObject create = Instantiate(cellPrefab);
			create.transform.SetParent(rootPanel);
			create.GetComponent<PrefabOnClick>().cell = this;
			lstController.Add(create.GetComponent<PrefabOnClick>());
		}
		InitSprite();
	}

	void InitSprite()
	{
		for(int i = 0; i < lstController.Count; i++)
		{
			int index = Random.Range(0, imgArray.Length);
			while(CheckImgIndex(imgArray[index]) >= (lstController.Count/imgArray.Length))
			{
				index = Random.Range(0,imgArray.Length);
			}
			lstController[i].img_2 = imgArray[index]; 

		}
	}

	int CheckImgIndex (Sprite sprites)
	{
		int currCount = 0;
		for(int i = 0; i < lstController.Count; i++)
		{
			if(sprites == lstController[i].img_2)
			{
				currCount++;
			}
			if(currCount >= (lstController.Count/imgArray.Length))
			{
				return currCount;
			}
		}
		return currCount;
	}

	public void CheckSameImg(PrefabOnClick check)
	{
		for(int i = 0; i < lstController.Count; i++)
		{
			if(lstController[i].imgCell.sprite == check.imgCell.sprite)
			{
				//lstController[i].GetComponent<GameObject>().SetActive= false;
				lstController[i].GetComponent<SpriteRenderer>().enabled = false;
				//check.GetComponent<GameObject>().SetActive= false;
				check.GetComponent<SpriteRenderer>().enabled = false;
			}
		}
	}
}
