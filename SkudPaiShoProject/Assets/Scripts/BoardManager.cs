using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour
{
    public int radius;
    public GameObject grid;
    public GameObject _Dynamic;

    private int radiusSquared;
    private int selectionX;
    private int selectionY;

    // Start is called before the first frame update
    void Start()
    {
        if(_Dynamic == null)
        {
            _Dynamic = GameObject.Find("_Dynamic");
        }

        DrawChessBoard();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateSelection();
    }

    private void DrawChessBoard()
    {
        radiusSquared = radius * radius;
        for (int x = -radius; x <= radius; ++x)
        {
            for (int y = -radius; y <= radius; ++y)
            {
                if(new Vector2(x,y).sqrMagnitude <= radiusSquared)
                {
                    if (x != radius && x != -radius && y != radius && y != -radius)
                    {
                        GameObject block = Instantiate(grid, new Vector3(x, 0, y), Quaternion.identity);
                        block.transform.SetParent(_Dynamic.transform);
                    }
                }
            }
        }
    }

    private void UpdateSelection()
    {
        if (!Camera.main) return;

        RaycastHit hit;
        float raycastDistance = 25.0f;
        if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, raycastDistance, LayerMask.GetMask("TilePlane")))
        {
            selectionX = (int)hit.point.x;
            selectionY = (int)hit.point.y;

            if (hit.transform != null)
                hit.transform.GetComponent<Renderer>().material.color = Color.red;
        }
        else
        {
            selectionX = -1;
            selectionY = -1;

            if(hit.transform != null)
                hit.transform.GetComponent<Renderer>().material.color = Color.white;
        }
    }
}
