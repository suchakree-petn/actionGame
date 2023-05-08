using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Logic_Minimax : MonoBehaviour
{
    int boardMax = 3;
    public char[,] board = new char[3, 3];
    public int[] Move = { 0, 0 };
    public char ai = 'X';
    public char human = 'O';
    public char currentPlayer;
    char result;
    public GameControllerSpecialStage gameControllerSpecialStage;
    void Start()
    {
        currentPlayer = ai;
        InitialBoard();

    }
    public void PlayerMove(int i, int j)
    {
        if (currentPlayer == human)
        {
            int[] input = { i, j };

            if (board[input[0], input[1]] == '-')
            {
                board[input[0], input[1]] = human;
                currentPlayer = ai;
                WriteResult();

            }
            else
            {
                Debug.Log("Not Empty");
            }
        }
        else
        {
            Debug.Log("currentPlayer is not human");
        }
    }
    void InitialBoard()
    {
        for (int i = 0; i < boardMax; i++)
        {
            for (int j = 0; j < boardMax; j++)
            {
                board[i, j] = '-';
            }
        }
    }
    public void WriteResult()
    {
        int count = 0;
        foreach (char c in board)
        {
            if (c != '-')
            {
                count++;
            }
        }
        Debug.Log("Board count: " + count);
        result = checkWinner3();
        if (result == ' ')
        {
            Debug.Log("No Winner");
            return;
        }
        if (result == 'T')
        {
            gameControllerSpecialStage.GetComponent<GameOver>().OnStageTie_SpecialStage();
            return;
        }
        else
        {
            if (result == 'O')
            {
                gameControllerSpecialStage.GetComponent<GameOver>().OnStageWin_SpecialStage();
                return;
            }
            if (result == 'X')
            {
                gameControllerSpecialStage.GetComponent<GameOver>().OnStageOver_SpecialStage();
                return;
            }
        }
    }

    public void move(int i, int j)
    {
        Move[0] = i;
        Move[1] = j;
    }

    public int bestMove()
    {
        int bestScore = int.MinValue;
        for (int j = 0; j < boardMax; j++)
        {
            for (int i = 0; i < boardMax; i++)
            {
                if (board[i, j] == '-')
                {
                    board[i, j] = ai;
                    int score = minimax(board, 0, false);
                    board[i, j] = '-';
                    if (score > bestScore)
                    {
                        bestScore = score;
                        move(i, j);
                    }
                }
            }
        }
        board[Move[0], Move[1]] = ai;
        currentPlayer = human;
        WriteResult();

        return ConvertMoveToInt(Move);
    }
    public int ConvertMoveToInt(int[] Move)
    {

        switch (Move[0])
        {
            case 0:
                switch (Move[1])
                {
                    case 0:
                        return 7;
                    case 1:
                        return 8;
                    case 2:
                        return 9;
                }
                break;
            case 1:
                switch (Move[1])
                {
                    case 0:
                        return 6;
                    case 1:
                        return 5;
                    case 2:
                        return 4;
                }
                break;
            case 2:
                switch (Move[1])
                {
                    case 0:
                        return 1;
                    case 1:
                        return 2;
                    case 2:
                        return 3;
                }
                break;
        }
        return 0;
    }

    int scores(char result)
    {
        if (result == 'X')
        {
            return 10;
        }
        else if (result == 'O')
        {
            return -10;
        }
        else if (result == 'T')
        {
            return 0;
        }
        Debug.Log("-11");
        return -11;
    }

    int minimax(char[,] board, int depth, bool isMaximizing)
    {
        char result = checkWinner3();
        if (result != ' ')
        {
            return scores(result);
        }

        if (isMaximizing)
        {
            int bestScore = int.MinValue;
            for (int i = 0; i < boardMax; i++)
            {
                for (int j = 0; j < boardMax; j++)
                {
                    if (board[i, j] == '-')
                    {
                        board[i, j] = ai;
                        int score = minimax(board, depth + 1, false);
                        board[i, j] = '-';
                        bestScore = max(score, bestScore);
                    }
                }
            }
            return bestScore;
        }
        else
        {
            int bestScore = int.MaxValue;
            for (int i = 0; i < boardMax; i++)
            {
                for (int j = 0; j < boardMax; j++)
                {
                    if (board[i, j] == '-')
                    {
                        board[i, j] = human;
                        int score = minimax(board, depth + 1, true);
                        board[i, j] = '-';
                        bestScore = min(score, bestScore);
                    }
                }
            }
            return bestScore;
        }
    }
    public void Remove(int[] move)
    {
        gameControllerSpecialStage.EnemyTurn(gameControllerSpecialStage.logic_Minimax.bestMove());
        board[move[0], move[1]] = '-';
        gameControllerSpecialStage.selected.Remove(ConvertMoveToInt(move));
        foreach (Transform child in gameControllerSpecialStage.stage_Stage.platforms.transform)
        {
            if (child.gameObject.name == ConvertMoveToInt(move).ToString())
            {
                Destroy(child.GetComponent<SetPosition>().UI_Instance);
                return;
            }
        }

    }
    bool equals3(char a, char b, char c)
    {
        return a == b && b == c && a != '-';
    }
    int max(int i, int j)
    {
        if (i > j)
        {
            return i;
        }
        else
        {
            return j;
        }
    }
    int min(int i, int j)
    {
        if (i < j)
        {
            return i;
        }
        else
        {
            return j;
        }
    }

    char checkWinner3()
    {
        char winner = ' ';

        // horizontal
        for (int i = 0; i < boardMax; i++)
        {
            if (equals3(board[i, 0], board[i, 1], board[i, 2]))
            {
                winner = board[i, 0];

            }
        }

        // Vertical
        for (int i = 0; i < boardMax; i++)
        {
            if (equals3(board[0, i], board[1, i], board[2, i]))
            {
                winner = board[0, i];

            }
        }

        // Diagonal
        if (equals3(board[0, 0], board[1, 1], board[2, 2]))
        {
            winner = board[0, 0];

        }
        if (equals3(board[2, 0], board[1, 1], board[0, 2]))
        {
            winner = board[2, 0];

        }

        int openSpots = 0;
        for (int i = 0; i < boardMax; i++)
        {
            for (int j = 0; j < boardMax; j++)
            {
                if (board[i, j] == '-')
                {
                    openSpots++;
                }
            }
        }

        if (winner == ' ' && openSpots == 0)
        {
            return 'T';
        }
        else
        {
            return winner;
        }
    }
}
