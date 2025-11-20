using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Cell {
	public bool visited;
	public GameObject north;//1
	public GameObject east;//2
	public GameObject west;//3
	public GameObject south;//4

}
public class Generator : MonoBehaviour {
	private GameObject wallHolder, tempWall;
	public int row , column;
	public float wallLength = 1.0f;
	private Vector3 startPosition;
	private int currentCell = 0;
	public Cell[] cells;
	private int totalCells;
	private int currentNeighbour = 0;
	private int backingUp = 0;
	private int[] neighbour = new int[4];
	private int[] connectingWall = new int[4];

	List<int> cellList;

    void Start()
    {
        CreateWall();
		wallHolder.transform.position = new Vector3(0, wallLength / 2, 0);
		wallHolder.transform.Find($"row 0,0").gameObject.SetActive(false);
		wallHolder.transform.Find($"row 20,19").gameObject.SetActive(false);
		cellList.Clear();
		wallHolder = null;
		tempWall = null;
		cells = null;
		GameObject.Find("")
    }

	/// <summary>
	/// Creating wall gameobject based on rows and columns given
	/// </summary>
	public void CreateWall()
	{
		wallHolder = GameObject.FindGameObjectWithTag("Walls");
		totalCells = row * column;

		startPosition = new Vector3(0, 0, 0);
		Vector3 myPos;
		
		//for creating columns
		for (int a = 0; a < row; a++)
		{
			for (int b = 0; b <= column; b++)
			{
				myPos = new Vector3(startPosition.x + (b * wallLength) - wallLength/2 ,0.0f, startPosition.z +(a * wallLength) - wallLength/2);
				tempWall = wallHolder.transform.Find($"column {a},{b}")?.gameObject;
				tempWall.SetActive(true);
				tempWall.transform.position = myPos;
			}
		}

		//for creating rows
		for (int a = 0; a <= row; a++)
		{
			for (int b = 0; b < column; b++)
			{
				myPos = new Vector3(startPosition.x + (b * wallLength) , 0.0f, startPosition.z +( a * wallLength) - wallLength);
				tempWall = wallHolder.transform.Find($"row {a},{b}")?.gameObject;
				tempWall.SetActive(true);
				tempWall.transform.Rotate(Vector3.up, 90);
				tempWall.transform.position = myPos;
			}
		}
		CreateCells();
	}
	
	/// <summary>
	/// Assigning created walls to the cells direction (north,east,west,south)
	/// </summary>
	public void CreateCells()
	{ 	
		cellList = new List<int>();
		int children = wallHolder.transform.childCount;
		GameObject[] allWalls = new GameObject[children];
		cells = new Cell[totalCells];

		int eastWestProccess = 0;
		int childProcess = 0;
		int termCount = 0;
		int cellProccess = 0;
		
		//Assigning all the walls to the allwalls array
		for (int i = 0; i < children; i++)
		{
			allWalls[i] = wallHolder.transform.GetChild(i).gameObject;
		}

		//Assigning walls to the cells
		for (int j = 0; j < column; j++)
		{
			cells[cellProccess] = new Cell();
			
			cells[cellProccess].west = allWalls[eastWestProccess];
			cells[cellProccess].south = allWalls[childProcess + (column + 1) * row];
			termCount++;
			childProcess++;
			cells[cellProccess].north = allWalls[(childProcess + (column + 1) * row)+ column - 1];
			eastWestProccess++;
			cells[cellProccess].east = allWalls[eastWestProccess];
		
			cellProccess++;
			if(termCount == column && cellProccess < cells.Length)			
			{
				eastWestProccess ++;
				termCount = 0;
				j = -1;
			}
			
		}
		CreateMaze();
	}

	/// <summary>
	/// Getting a random neighbour if not visited and wall between them
	/// </summary>
	void GiveMeNeighbour()
	{
		int length = 0;
		int check = 0;
		check = (currentCell + 1) / column;
		check -=1;
		check *= column;
		check += column;
		//north
		if (currentCell + column < totalCells)
		{
			if (cells[currentCell + column].visited == false)
			{
				neighbour[length] = currentCell + column;
				connectingWall[length] = 1;
				length++;
			}
		}
		//east
		if (currentCell + 1 < totalCells && (currentCell + 1) != check)
		{
			if (cells[currentCell + 1].visited == false)
			{
				neighbour[length] = currentCell + 1;
				connectingWall[length] = 2;
				length++;
			}
		}
		//west
		if (currentCell - 1 >= 0 && currentCell != check)
		{
			if (cells[currentCell - 1].visited == false)
			{
				neighbour[length] = currentCell - 1;
				connectingWall[length] = 3;
				length++;
			}
		}
		//south
		if (currentCell - column >=  0)
		{
			if (cells[currentCell - column].visited == false)
			{
				neighbour[length] = currentCell - column;
				connectingWall[length] = 4;
				length++;
			}
		}

		//Getting random neighbour and destroying the wall
		if (length != 0)
		{
			int randomNeighbour = Random.Range(0,length);
			currentNeighbour = neighbour[randomNeighbour];
			DestroyWall(connectingWall[randomNeighbour]);
		}
		else if (backingUp > 0)
		{
			currentCell = cellList[backingUp];
			backingUp--;
		}
	}
	
	void CreateMaze()
	{
		bool startedBuilding = false;
		int visitedCells = 0;
		while(visitedCells < totalCells)
		{
			if(startedBuilding)
			{
				GiveMeNeighbour();
				if (!cells[currentNeighbour].visited && cells[currentCell].visited)
				{
					cells[currentNeighbour].visited = true;
					visitedCells++;
					cellList.Add(currentCell);
					currentCell = currentNeighbour;
		
					if (cellList.Count > 0)
						backingUp = cellList.Count - 1;
				}
			}
			else
			{
				currentCell = Random.Range(0,totalCells);
				cells[currentCell].visited = true;
				visitedCells++;
				startedBuilding = true;
			}
		}
	}

	void DestroyWall(int neighbour)
	{
		switch (neighbour)
		{
			//case 1 means north wall
			case 1 : 
				cells[currentCell].north.SetActive(false);
			break;

			//case 2 means east wall
			case 2 : 
				cells[currentCell].east.SetActive(false);
			break;
			
			//case 3 means west wall
			case 3 :
				cells[currentCell].west.SetActive(false);
			break;
			
			//case 4 means south wall
			case 4 : 
				cells[currentCell].south.SetActive(false);	
			break;
			
			default:
			break;
		}
	}

}





