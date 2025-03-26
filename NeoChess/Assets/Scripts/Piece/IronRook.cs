using System;
using UnityEngine;

public class IronRook : Piece
{
    private int skillRange = 3;
    private int cooldown = 3;
    private int currentCooldown = 0;
    private bool isSkillActive;

    public override void Initialize(Character roleData, string side, int x, int y, float scale)
    {
        base.Initialize(roleData, side, x, y, scale);
        isSkillActive = false;
    }

    public override bool CanMove(int toX, int toY, GameObject[,] board)
    {
        if (toX != x && toY != y) return false;
        int maxRange = isSkillActive ? int.MaxValue : 8;

        int minX = Mathf.Min(x, toX);
        int maxX = Mathf.Max(x, toX);
        int minY = Mathf.Min(y, toY);
        int maxY = Mathf.Max(y, toY);

        if (toX == x)
        {
            if (Mathf.Abs(toY - y) > maxRange) return false;
            for (int i = minY + 1; i < maxY; i++)
                if (board[toX, i] != null) return false;
        }
        else if (toY == y)
        {
            if (Mathf.Abs(toX - x) > maxRange) return false;
            for (int i = minX + 1; i < maxX; i++)
                if (board[i, toY] != null) return false;
        }
        return true;
    }

    public override void UseSkill(int targetX, int targetY, GameObject[,] board)
    {
        if (currentCooldown > 0) return;
        if (Vector2Int.Distance(new Vector2Int(x, y), new Vector2Int(targetX, targetY)) <= skillRange)
        {
            Debug.Log("装甲冲锋：本回合直线移动无距离限制！");
            isSkillActive = true;
            currentCooldown = cooldown;
        }
    }
}