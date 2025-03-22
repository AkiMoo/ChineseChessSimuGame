using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour
{
    public GameObject[,] board = new GameObject[10, 9];
    public GameObject piecePrefab;

    void Start(){
        InitializeBoard();
    }
    //初始化放置棋子
    void InitializeBoard(){
        //PlacePieces(0,0,"Rook","Side");
    }

    void PlacePieces(int x,int y,Character character,string side){
        Vector3 position = new Vector3(x,y,0);
        //Quaternion.identity 表示不进行旋转
        GameObject piece = Instantiate(piecePrefab, position, Quaternion.identity);
        piece.GetComponent<Piece>().Initialize(character, side, x, y);
        board[x,y] = piece;
    }

    public void MovePiece(int x,int y,int newX,int newY){
        GameObject piece = board[x,y];
        if(piece != null){
            board[x,y] = null;
            board[newX,newY] = piece;
            piece.transform.position = new Vector3(newX,newY,0);
        }
    }
}
