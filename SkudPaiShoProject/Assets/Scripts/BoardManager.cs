using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour
{
    public enum playerSide { Host, Guest };

    public int radius;
    public GameObject grid;
    public GameObject _Dynamic;

    public List<GameObject> homeTiles;
    public List<GameObject> guestTiles;



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

        if(guestTiles.Count != 0)
        {
            foreach (var item in guestTiles)
            {
                var temp = item.GetComponent<PaiShoTile>();
                if (temp.side != playerSide.Guest)
                {
                    temp.side = playerSide.Guest;
                }
            }
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
        }
        else
        {
            selectionX = -1;
            selectionY = -1;
        }
    }
}
