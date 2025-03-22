using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Piece : MonoBehaviour
{
    public string characterName;
    public string pieceType;
    public string side;
    public int x, y;
    public int startHp;
    public int currentHp;
    //这里还要添加技能变量

    public virtual void Initialize(Character character, string side, int x, int y){
        this.characterName = character.characterName;
        this.pieceType = character.pieceType;
        this.startHp = character.startHp;
        this.side = side;
        this.x = x;
        this.y = y;
    }
    //抽象方法：子类必须重写移动规则
    public abstract bool CanMove(int x, int y, GameObject[,] board);
    public virtual void TakeDamage(int damage){
        currentHp -= damage;
        if(currentHp <= 0){
            //目前是直接移除，如果要引入灵魂系统的话应该要在这里实现。
            Destroy(gameObject);
        }
    }
}
