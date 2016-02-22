using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Grid : MonoBehaviour {

	public Sprite cellImg;
	public Sprite imgChangeClick;
	public GridLayoutGroup gridLayoutGroup;
	public RectTransform recTrans;
	public Sprite sprX;
	public Sprite sprO;

	void Awake()
	{
		gridLayoutGroup = GetComponent<GridLayoutGroup>();
		recTrans = GetComponent<RectTransform>();
	}
	public void InitGameBoard(int rows, int cols)
	{
		gridLayoutGroup.constraint = GridLayoutGroup.Constraint.FixedRowCount;
		gridLayoutGroup.constraintCount = rows;
		for (int i = 0; i < rows * cols; i++)
		{
			GameObject newCell = new GameObject("NewCell");
			newCell.AddComponent<Image>().sprite = (cellImg);
			Cell cell = newCell.AddComponent<Cell>();
			cell.Init(sprX,sprO);

			newCell.GetComponent<RectTransform>().SetParent(recTrans);
		}
	}
}
