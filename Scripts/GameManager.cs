using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public int rows;
	public int cols;
	public Grid grid;
	// Use this for initialization
	void Start () {
		grid.InitGameBoard(rows,cols);
	}
}
