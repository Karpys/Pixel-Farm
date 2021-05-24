using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridCreate : MonoBehaviour
{
    // Start is called before the first frame update
    public int StartFarmHeight;
    public int StartFarmWidth;
    public int Height;
    public int Width;
    public GameObject Grid;
    public GameObject GridHolder;
    public List<List<GameObject>> ListGrid = new List<List<GameObject>>();
    void Start()
    {
        for(int i=0;i<Width;i++)
        {
            List<GameObject> TempList = new List<GameObject>();
            ListGrid.Add(TempList);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            CreateGrid(StartFarmWidth, StartFarmHeight,Width,Height);
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            DevAllGrid();
        }
    }

    public void DevAllGrid()
    {
        for(int i=0;i<ListGrid.Count;i++)
        {
            for(int j=0;j<ListGrid[i].Count;j++)
            {
                DevelopGrid(i, j);
            }
        }
    }

    public void CreateGrid(int StartPosx,int StartPosy,int Width, int Height)
    {

        for (int i = 0; i < Width; i++)
        {
            for (int j = 0; j < Height; j++)
            {
                GameObject Gri = Instantiate(Grid, new Vector3(i + StartPosx, -j + StartPosy, 0), transform.rotation, GridHolder.transform);
                Gri.name = i + " " + j;
                ListGrid[i].Add(Gri);
            }
        }
    }

    public void DevelopGrid(int posx,int posy)
    {
        if(posx<ListGrid.Count)
        {
            if(posy<ListGrid[posx].Count)
            {
                ListGrid[posx][posy].GetComponent<GridController>().Herbs();
            }else
            {
                return;
            }
        }else
        {
            return;
        }
    }
}
