using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PaiShoTile : MonoBehaviour
{
    public int currentX { get; set; }
    public int currentY { get; set; }
    public BoardManager.playerSide side;

    public void SetPosition(int x, int y)
    {
        currentX = x;
        currentY = y;
    }

    public virtual bool[,] PossibleMove()
    {
        return new bool[16, 16];
    }
}
