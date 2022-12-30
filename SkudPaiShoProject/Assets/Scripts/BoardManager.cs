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

    public List<Vector3> gates;

    private Vector3 hostGate;
    private Vector3 guestGate;

    private int radiusSquared;
    private int selectionX;
    private int selectionY;

    private PaiShoTile selectedFigure;
    private playerSide currentTurn;

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

        hostGate = gates[0];
        guestGate = gates[2];
        currentTurn = playerSide.Host;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateSelection();
        
        if (Input.GetMouseButtonDown(0))
        {
            if (selectionX >= 0 && selectionY >= 0)
            {
                if (selectedFigure == null)
                {
                    SelectChessFigure(selectionX, selectionY);
                }
                else
                {
                    MoveChessFigure(selectionX, selectionY);
                }
            }
        }
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

    private void EndGame()
    {
        //if(currentTurn == playerSide.Host)
        //{
        //    Debug.Log("Host Team Won");
        //}
        //else
        //{
        //    Debug.Log("Guest Team Won");
        //}

        //foreach(GameObject obj in activeFigures)
        //{
        //    Destroy(obj);
        //}

        //currentTurn = playerSide.Host;
        //BoardHighlighting.Instance.HideHighlights();
        //SpawnChessFigures;
    }

    public void SelectChessFigure(int x, int y)
    {
        //if (ChessFigurePositions[x, y] == null) return;
        //if (ChessFigurePositions[x, y].side != currentTurn) return;

        //bool hasAtLeastOneMove = false;
        //allowedMoves = ChessFigurePositions[x, y].PossibleMove();

        //for (int i = 0; i < 18; i++)
        //{
        //    for (int j = 0; j < 18; j++)
        //    {
        //        if(new Vector2(i,j).sqrMagnitude <= radiusSquared)
        //        {
        //            if (allowedMoves[i, j])
        //            {
        //                hasAtLeastOneMove = true;
        //                i = 7;
        //                break;
        //            }
        //        }
        //    }
        //}

        //if (!hasAtLeastOneMove) return;

        //selectedFigure = ChessFigurePositions[x, y];
        //BoardHighlighting.Instance.HighlightAllowedMoves(allowedMoves);
    }

    public void MoveChessFigure(int x, int y)
    {
        //if (allowedMoves[x, y])
        //{
        //    PaiShoTile c = ChessFigurePositions[x, y];
        //    if (c != null && c.isWhite != isWhiteTurn)
        //    {
        //        activeFigures.Remove(c.gameObject);
        //        Destroy(c.gameObject);

        //        if (c.GetType() == typeof(King))
        //        {
        //            EndGame();
        //            return;
        //        }
        //    }

        //    ChessFigurePositions[selectedFigure.CurrentX, selectedFigure.CurrentY] = null;
        //    selectedFigure.transform.position = GetTileCenter(x, y);
        //    selectedFigure.SetPosition(x, y);
        //    ChessFigurePositions[x, y] = selectedFigure;
        //    isWhiteTurn = !isWhiteTurn;
        //}

        //BoardHighlighting.Instance.HideHighlights();
        //selectedFigure = null;
    }

    public Vector3 GetHostGate()
    {
        return hostGate;
    }

    public Vector3 GetGuestGate()
    {
        return guestGate;
    }
}
