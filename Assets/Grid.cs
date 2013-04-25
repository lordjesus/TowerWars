using UnityEngine;
using System.Collections;

public class Grid : MonoBehaviour {

    public int Width, Height;

    private int width, height;
    private float cellWidth, cellHeight;
    private float offset_x, offset_y;
    private GridCell[,] grid;
   

	// Use this for initialization
    void Start()
    {
        width = (int)(gameObject.transform.localScale.x * 10f);
        height = (int)(gameObject.transform.localScale.z * 10f);
        if (true)
        {
            Width = width;
            Height = height;
        }
        if (Width != 0 && Height != 0)
        {
            grid = new GridCell[Width, Height];

        }
        else
        {
            grid = new GridCell[width, height];
        }
        initGrid();
        Bounds b = gameObject.renderer.bounds;
        offset_x = b.min.x;
        offset_y = b.min.y;

        cellWidth = (b.max.x - b.min.x) / Width;
        cellHeight = (b.max.y - b.min.y) / Height;

        print(string.Format("Cell height: {0}, Cell width: {1}, offset_x: {2}, offset_y: {3}", cellHeight, cellWidth, offset_x, offset_y));
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void initGrid()
    {
        for (int i = 0; i < Width; i++)
        {
            for (int j = 0; j < Height; j++)
            {
                grid[i, j] = new GridCell();
            }
        }
    }

    public Vector2 GetGridCoords(float x, float y)
    {
        float px = (x - offset_x) / cellWidth;
        float py = (y - offset_y) / cellHeight;

        int ix = (int)px;
        int iy = (int)py;

        grid[ix, iy].State = GridState.OCCUPIED;

        print(string.Format("At plane ({0}, {1})", (int)px, (int)py));

        Vector2 retval = new Vector2();
        retval.x = ix * cellWidth + cellWidth / 2 + offset_x;
        retval.y = iy * cellHeight + cellHeight / 2 + offset_y;

        return retval;
    }
}


public class GridCell
{
    public GridState State
    {
        get;
        set;
    }

    public GridCell()
    {
        State = GridState.EMPTY;
    }
}

public enum GridState
{
    EMPTY, OCCUPIED, UNAVAILABLE,
}
