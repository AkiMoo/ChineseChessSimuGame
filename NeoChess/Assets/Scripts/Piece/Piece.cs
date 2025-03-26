using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public abstract class Piece : MonoBehaviour
{
    public string roleName;   // 角色名
    public string profession; // 职业
    public string side;       // 阵营（Red 或 Black）
    public int x, y;          // 逻辑坐标
    protected float scale;    // 从 BoardManager 获取缩放因子

    public virtual void Initialize(Character roleData, string side, int x, int y, float scale)
    {
        this.roleName = roleData.characterName;
        this.profession = roleData.pieceType;
        this.side = side;
        this.x = x;
        this.y = y;
        this.scale = scale;

        // 设置显示位置
        transform.position = new Vector3(x * scale, y * scale, 0);
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        if (sr != null)
        {
            sr.sortingLayerName = "Pieces";
            sr.sortingOrder = 1;
        }
    }

    public abstract bool CanMove(int toX, int toY, GameObject[,] board);
    public abstract void UseSkill(int targetX, int targetY, GameObject[,] board);
}
// public abstract class Piece : MonoBehaviour
// {
//     public string characterName;
//     public string pieceType;
//     public string side;
//     public int x, y;
//     public int startHp;
//     public int currentHp;
//     //这里还要添加技能变量

//     public virtual void Initialize(Character character, string side, int x, int y){
//         this.characterName = character.characterName;
//         this.pieceType = character.pieceType;
//         this.startHp = character.startHp;
//         this.side = side;
//         this.x = x;
//         this.y = y;
//     }
//     //抽象方法：子类必须重写移动规则
//     public abstract bool CanMove(int x, int y, GameObject[,] board);
//     public virtual void TakeDamage(int damage){
//         currentHp -= damage;
//         if(currentHp <= 0){
//             //目前是直接移除，如果要引入灵魂系统的话应该要在这里实现。
//             Destroy(gameObject);
//         }
//     }
// }
