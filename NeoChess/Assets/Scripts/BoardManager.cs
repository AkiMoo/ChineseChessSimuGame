using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour
{
    public GameObject[,] board = new GameObject[9, 10];
    public Character[] redRoles;   // 红方角色
    public Character[] blackRoles; // 黑方角色
    public GameObject ironRookPrefab;
    //public GameObject swiftHorsePrefab;

    private float scale; // 与 DrawBoard 同步

    void Start()
    {
        //scale = GetComponent<DrawBoard>().scale; // 从 DrawBoard 获取缩放因子
        scale = 1;
        InitializeBoard();
    }

    void InitializeBoard()
    {
        // 示例：放置红方和黑方的“铁甲战车”
        PlacePiece(0, 0, redRoles[0], "Red");   // 红方左车
        PlacePiece(8, 0, redRoles[0], "Red");   // 红方右车
        PlacePiece(0, 9, blackRoles[0], "Black"); // 黑方左车
        PlacePiece(8, 9, blackRoles[0], "Black"); // 黑方右车
    }

    void PlacePiece(int x, int y, Character roleData, string side)
    {
        GameObject prefab = null;
        switch (roleData.characterName)
        {
            case "IronRook": prefab = ironRookPrefab; break;
            //case "SwiftHorse": prefab = swiftHorsePrefab; break;
            default: Debug.LogError("未知角色: " + roleData.characterName); return;
        }

        GameObject piece = Instantiate(prefab, new Vector3(x * scale, y * scale, 0), Quaternion.identity);
        Piece pieceScript = piece.GetComponent<Piece>();
        pieceScript.Initialize(roleData, side, x, y, scale);
        board[x, y] = piece;
    }
}
// public class BoardManager : MonoBehaviour
// {
//     public GameObject[,] board = new GameObject[10, 9];
//     public GameObject piecePrefab;

//     void Start(){
//         InitializeBoard();
//     }
//     //初始化放置棋子
//     void InitializeBoard(){
//         //PlacePieces(0,0,"Rook","Side");
//     }

//     void PlacePieces(int x,int y,Character character,string side){
//         Vector3 position = new Vector3(x,y,0);
//         //Quaternion.identity 表示不进行旋转
//         GameObject piece = Instantiate(piecePrefab, position, Quaternion.identity);
//         piece.GetComponent<Piece>().Initialize(character, side, x, y);
//         board[x,y] = piece;
//     }

//     public void MovePiece(int x,int y,int newX,int newY){
//         GameObject piece = board[x,y];
//         if(piece != null){
//             board[x,y] = null;
//             board[newX,newY] = piece;
//             piece.transform.position = new Vector3(newX,newY,0);
//         }
//     }
// }
