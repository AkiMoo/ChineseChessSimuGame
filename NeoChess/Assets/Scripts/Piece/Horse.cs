using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Horse : Piece
{
    public override bool CanMove(int toX, int toY, GameObject[,] board)
    {
        int dx = Mathf.Abs(toX - x);
        int dy = Mathf.Abs(toY - y);
        //此处要检查技能效果
        

        if ((dx == 1 && dy == 2) || (dx == 2 && dy == 1))
        {
            if (dx == 2)
            {
                int midX = (x + toX) / 2;
                if (board[midX, y] != null) return false;
            }
            else if (dy == 2)
            {
                int midY = (y + toY) / 2;
                if (board[x, midY] != null) return false;
            }
            return true;
        }
        return false;
    }
}