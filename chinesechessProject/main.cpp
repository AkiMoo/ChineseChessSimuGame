#include <iostream>
#include <vector>
#include <limits>

using namespace std;

// 定义棋盘大小
const int BOARD_SIZE = 9;

// 定义玩家类型
enum Player {
    RED, BLACK
};

// 定义棋子类型
enum ChessPieceType {
    EMPTY, JIANG, SHI, XIANG, CHE, MA, PAO, BING
};

// 定义棋子类
class ChessPiece {
public:
    ChessPieceType type;
    Player player;

    ChessPiece(ChessPieceType t, Player p) : type(t), player(p) {}
};

// 定义棋盘类
class ChessBoard {
private:
    ChessPiece board[BOARD_SIZE][BOARD_SIZE];

public:
    ChessBoard() {
        initializeBoard();
    }

    // 初始化棋盘
    void initializeBoard() {
        // 在这里按照规则初始化棋盘
        // 这里只是一个简单的示例
        // 初始化棋盘状态
        for (int i = 0; i < BOARD_SIZE; ++i) {
            for (int j = 0; j < BOARD_SIZE; ++j) {
                board[i][j] = ChessPiece(EMPTY, RED);
            }
        }
        // 初始化红方棋子
        board[0][0] = ChessPiece(CHE, RED);
        board[0][1] = ChessPiece(MA, RED);
        // 其他红方棋子初始化省略

        // 初始化黑方棋子
        board[9][0] = ChessPiece(CHE, BLACK);
        board[9][1] = ChessPiece(MA, BLACK);
        // 其他黑方棋子初始化省略
    }

    // 在控制台上显示当前棋盘状态
    void display() {
        for (int i = 0; i < BOARD_SIZE; ++i) {
            for (int j = 0; j < BOARD_SIZE; ++j) {
                displayChessPiece(board[i][j]);
            }
            cout << endl;
        }
    }

    // 在控制台上显示单个棋子
    void displayChessPiece(const ChessPiece& piece) {
        switch (piece.type) {
            case EMPTY: cout << " . "; break;
            case JIANG: cout << (piece.player == RED ? " 红将 " : " 黑将 "); break;
            case SHI: cout << (piece.player == RED ? " 红士 " : " 黑士 "); break;
            case XIANG: cout << (piece.player == RED ? " 红相 " : " 黑象 "); break;
            case CHE: cout << (piece.player == RED ? " 红车 " : " 黑车 "); break;
            case MA: cout << (piece.player == RED ? " 红马 " : " 黑马 "); break;
            case PAO: cout << (piece.player == RED ? " 红炮 " : " 黑炮 "); break;
            case BING: cout << (piece.player == RED ? " 红兵 " : " 黑卒 "); break;
            default: break;
        }
    }

    // 移动棋子
    void movePiece(int fromX, int fromY, int toX, int toY) {
        // 在这里添加移动棋子的逻辑
        // 需要检查移动是否符合规则，以及是否吃子等情况
        // 这里只是一个简单的示例
        board[toX][toY] = board[fromX][fromY];
        board[fromX][fromY] = ChessPiece(EMPTY, RED);  // 清空原来位置
    }

    // 检查是否将军
    bool isCheck(Player player) {
        // 在这里添加将军判断的逻辑
        // 这里只是一个简单的示例
        // 假设将军为对方的将在纵向上和横向上都被攻击
        int kingX, kingY;
        ChessPieceType kingType = (player == RED) ? JIANG : JIANG;
        findKingPosition(player, kingX, kingY);
        // 检查横向是否有棋子可以攻击将军
        for (int i = 0; i < BOARD_SIZE; ++i) {
            if (board[i][kingY].type != EMPTY && board[i][kingY].type != kingType) {
                return true;
            }
        }
        // 检查纵向是否有棋子可以攻击将军
        for (int j = 0; j < BOARD_SIZE; ++j) {
            if (board[kingX][j].type != EMPTY && board[kingX][j].type != kingType) {
                return true;
            }
        }
        return false;
    }

    // 寻找将军的将的位置
    void findKingPosition(Player player, int& x, int& y) {
        ChessPieceType kingType = (player == RED) ? JIANG : JIANG;
        for (int i = 0; i < BOARD_SIZE; ++i) {
            for (int j = 0; j < BOARD_SIZE; ++j) {
                if (board[i][j].type == kingType && board[i][j].player == player) {
                    x = i;
                    y = j;
                    return;
                }
            }
        }
    }

    // 判断游戏是否结束
    bool isGameOver() {
        // 在这里添加游戏结束判断的逻辑
        // 这里只是一个简单的示例，假设任一方的将被吃就结束游戏
        return !isCheck(RED) || !isCheck(BLACK);
    }
};

// 处理用户输入
int getUserInput() {
    int input;
    cout << "请输入要移动的棋子位置和目标位置（例如：12 表示从第1行第2列移动到第2行第2列）：" << endl;
    cin >> input;

    // 清除输入缓冲区
    cin.clear();
    cin.ignore(numeric_limits<streamsize>::max(), '\n');

    return input;
}

int main() {
    ChessBoard chessboard;

    // 显示初始棋盘状态
    chessboard.display();

    // 游戏循环等待玩家输入和移动棋子的操作
    while (!chessboard.isGameOver()) {
        int input = getUserInput();

        // 解析用户输入
        int fromX = input / 10 - 1;
        int fromY = input % 10 - 1;
        int toX, toY;

        cout << "请输入目标位置：" << endl;
        cin >> toX >> toY;

        // 移动棋子
        chessboard.movePiece(fromX, fromY, toX - 1, toY - 1);

        // 显示移动后的棋盘状态
        chessboard.display();

        // 判断是否将军
        if (chessboard.isCheck(BLACK)) {
            cout << "黑方被将军！" << endl;
        }
        if (chessboard.isCheck(RED)) {
            cout << "红方被将军！" << endl;
        }
    }

    cout << "游戏结束！" << endl;

    return 0;
}


void ChessBoard::movePiece(int fromX, int fromY, int toX, int toY) {
    // 检查起始位置是否合法
    if (fromX < 0 || fromX >= BOARD_SIZE || fromY < 0 || fromY >= BOARD_SIZE ||
        toX < 0 || toX >= BOARD_SIZE || toY < 0 || toY >= BOARD_SIZE) {
        cout << "移动位置不合法，请重新输入。" << endl;
        return;
    }

    ChessPiece& sourcePiece = board[fromX][fromY];
    ChessPiece& targetPiece = board[toX][toY];

    // 检查是否移动到相同位置
    if (fromX == toX && fromY == toY) {
        cout << "移动到相同位置，请重新输入。" << endl;
        return;
    }

    // 检查是否移动到己方棋子上
    if (sourcePiece.player == targetPiece.player) {
        cout << "不能移动到己方棋子上，请重新输入。" << endl;
        return;
    }

    // 检查具体棋子的移动规则
    switch (sourcePiece.type) {
        case JIANG:
            // 将的移动规则，只能在九宫格内移动，不能出九宫格，每次只能移动一格
            if ((abs(toX - fromX) == 1 && abs(toY - fromY) == 0) ||
                (abs(toX - fromX) == 0 && abs(toY - fromY) == 1)) {
                // 移动合法
                break;
            } else {
                cout << "将的移动规则不合法，请重新输入。" << endl;
                return;
            }

        // 其他棋子的移动规则可以在这里添加

        default:
            // 其他棋子暂时不处理，你需要根据规则逐个添加
            break;
    }

    // 执行移动
    targetPiece = sourcePiece;
    sourcePiece = ChessPiece(EMPTY, RED);  // 清空原位置
}


void ChessBoard::initializeBoard() {
    // 初始化棋盘状态
    for (int i = 0; i < BOARD_SIZE; ++i) {
        for (int j = 0; j < BOARD_SIZE; ++j) {
            board[i][j] = ChessPiece(EMPTY, RED);
        }
    }

    // 初始化红方棋子
    board[0][0] = ChessPiece(CHE, RED);
    board[0][1] = ChessPiece(MA, RED);
    board[0][2] = ChessPiece(XIANG, RED);
    // 其他红方棋子初始化省略

    // 初始化黑方棋子
    board[9][0] = ChessPiece(CHE, BLACK);
    board[9][1] = ChessPiece(MA, BLACK);
    board[9][2] = ChessPiece(XIANG, BLACK);
    // 其他黑方棋子初始化省略

    // 初始化兵（卒）
    for (int i = 0; i < BOARD_SIZE; ++i) {
        board[3][i] = ChessPiece(BING, RED);
        board[6][i] = ChessPiece(BING, BLACK);
    }

    // 初始化将（帅）、士、炮
    board[0][3] = ChessPiece(JIANG, RED);
    board[0][4] = ChessPiece(SHI, RED);
    board[0][5] = ChessPiece(XIANG, RED);
    board[0][6] = ChessPiece(CHE, RED);
    board[0][7] = ChessPiece(MA, RED);
    board[0][8] = ChessPiece(PAO, RED);
    // 其他红方棋子初始化省略

    board[9][3] = ChessPiece(JIANG, BLACK);
    board[9][4] = ChessPiece(SHI, BLACK);
    board[9][5] = ChessPiece(XIANG, BLACK);
    board[9][6] = ChessPiece(CHE, BLACK);
    board[9][7] = ChessPiece(MA, BLACK);
    board[9][8] = ChessPiece(PAO, BLACK);
    // 其他黑方棋子初始化省略
}
