using UnityEngine;

public class DrawBoard : MonoBehaviour
{
    [SerializeField] public float scale = 1f; // 间距缩放因子
    private float lastScale; // 记录上一次的 scale 值
    void Start()
    {
        lastScale = scale;
        DrawChessBoard();
    }
    void Update()
    {
        // 检测 scale 是否变化
        if (Mathf.Abs(scale - lastScale) > 0.001f) // 避免浮点误差
        {
            ClearChessBoard(); // 清除旧线条
            DrawChessBoard();  // 重绘棋盘
            UpdateCamera();
            lastScale = scale; // 更新记录
        }
    }

    void DrawChessBoard()
    {
        // 绘制横线
        for (int y = 0; y <= 9; y++)
        {
            CreateLine($"HorizontalLine_{y}", new Vector3(0, y * scale, 0), new Vector3(8 * scale, y * scale, 0));
        }

        // 绘制纵线（考虑楚河汉界）
        for (int x = 0; x <= 8; x++)
        {
            CreateLine($"VerticalLine_{x}_Bottom", new Vector3(x * scale, 0, 0), new Vector3(x * scale, 4 * scale, 0));
            CreateLine($"VerticalLine_{x}_Top", new Vector3(x * scale, 5 * scale, 0), new Vector3(x * scale, 9 * scale, 0));
        }

        // 绘制九宫斜线
        CreateLine("PalaceLine_Red_1", new Vector3(3 * scale, 0 * scale, 0), new Vector3(5 * scale, 2 * scale, 0));
        CreateLine("PalaceLine_Red_2", new Vector3(5 * scale, 0 * scale, 0), new Vector3(3 * scale, 2 * scale, 0));
        CreateLine("PalaceLine_Black_1", new Vector3(3 * scale, 7 * scale, 0), new Vector3(5 * scale, 9 * scale, 0));
        CreateLine("PalaceLine_Black_2", new Vector3(5 * scale, 7 * scale, 0), new Vector3(3 * scale, 9 * scale, 0));

        // 添加楚河汉界文字
        AddRiverText();
    }

    void CreateLine(string name, Vector3 start, Vector3 end)
    {
        GameObject lineObj = new GameObject(name);
        lineObj.transform.parent = transform;
        LineRenderer lr = lineObj.AddComponent<LineRenderer>();
        
        lr.positionCount = 2;
        lr.startWidth = 0.05f;
        lr.endWidth = 0.05f;
        lr.loop = false;
        lr.SetPosition(0, start);
        lr.SetPosition(1, end);

        Material mat = new Material(Shader.Find("Sprites/Default"));
        mat.color = Color.black;
        lr.material = mat;

        lr.sortingLayerName = "Line";
        lr.sortingOrder = 0;
    }

    void AddRiverText()
    {
        GameObject textObj = new GameObject("RiverText");
        textObj.transform.parent = transform;
        TextMesh textMesh = textObj.AddComponent<TextMesh>();
        
        textMesh.text = "楚河  汉界";
        textMesh.fontSize = 10*(int)scale;
        textMesh.color = Color.black;
        textMesh.anchor = TextAnchor.MiddleCenter;
        textMesh.alignment = TextAlignment.Center;

        float riverY = 4.5f * scale;
        textObj.transform.position = new Vector3(4 * scale, riverY, -1);
    }
    void UpdateCamera()
    {
        Camera.main.orthographicSize = 9 * scale / 2 + 1; // 高度的一半加余量
        Camera.main.transform.position = new Vector3(8 * scale / 2, 9 * scale / 2, -10);
    }
    void ClearChessBoard()
    {
        // 销毁所有子对象（旧线条和文字）
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
    }
}