using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Rook : Piece
{
    public override bool CanMove(int toX, int toY, GameObject[,] board)
    {
        if(toX != x && toY != y)
            return false;
        //因为不能越过棋子，所以要检测路线之间是否有棋子
        int minX = Mathf.Min(x, toX);
        int maxX = Mathf.Max(x, toX);
        int minY = Mathf.Min(y, toY);
        int maxY = Mathf.Max(y, toY);
        if (toX == x)
        {
            for (int i = minY + 1; i < maxY; i++)
                if (board[toX, i] != null) return false;
        }
        else if (toY == y)
        {
            for (int i = minX + 1; i < maxX; i++)
                if (board[i, toY] != null) return false;
        }
        return true;
    }
}
