using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SocketIO;
using UnityEngine.UI;

public class TictactoeManager : MonoBehaviour
{
    public List<Cell> cellList;

    public Cell cell;

    public Transform cellPos;

    // 플레이어의 마커타입
    private MarkerType playerMakerType;

    // 현재 게임의 상태
    private enum GameState { None, PlayerTurn, OpponentTurn, GameOver }
    // 현재 게임 상태
    private GameState currentState;
    private GameState CurrentState
    {
        get
        {
            return currentState;
        }
        set
        {
            switch (value)
            {
                case GameState.None:
                case GameState.OpponentTurn:
                case GameState.GameOver:
                    SetActiveTouchCells(false);
                    break;
                case GameState.PlayerTurn:
                    SetActiveTouchCells(true);
                    break;
            }
            currentState = value;
        }
    }

    // 승리 판정
    private enum Winner { None, Player, Opponent, Tie }

    // Grid의 행과 열의 수
    public int rowColNum;

    //SocketIO
    public SocketIOComponent socket;

    private void Start()
    {
        // 임시 코드
        playerMakerType = MarkerType.Circle;
        CurrentState = GameState.PlayerTurn;
        SetCell();
    }

    private void Update()
    {
        if (CurrentState == GameState.PlayerTurn)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Vector2 pos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
                RaycastHit2D hitInfo = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(pos), Vector2.zero);

                if (hitInfo && hitInfo.transform.tag == "Cell")
                {
                    Cell cell = hitInfo.transform.GetComponent<Cell>();

                    cell.MarkerType = playerMakerType;
                    Winner winner = CheckWinner();

                    switch (winner)
                    {
                        case Winner.None:
                            // TODO: currentState를 상대턴으로 변경
                            // 서버에게 상대가 게임을 진행할 수 있도록 메시지 전달
                            CurrentState = GameState.OpponentTurn;

                            break;
                        case Winner.Player:
                            // TODO: 승리 팝업창 표시
                            // 서버에게 Player가 승리했음을 알림
                            CurrentState = GameState.GameOver;

                            break;
                        case Winner.Tie:
                            // TODO: 비겼음을 팝업창으로 표시
                            // 서버에게 비겼음을 알림
                            CurrentState = GameState.GameOver;

                            break;
                    }
                }
            }
        }
    }

    public void SetCell()
    {
        int k = 0;
        for (int i = 0; i < rowColNum; i++)
        {
            for (int j = 0; j < rowColNum; j++)
            {
                Cell Tmp = Instantiate(cell, new Vector3((j * 2) - 2, -(i * 2) + 2, 1), Quaternion.identity, cellPos);
                cellList.Add(Tmp);
            }
        }
    }

    void SetActiveTouchCells(bool active)
    {
        foreach (Cell cell in cellList)
        {
            cell.SetActiveTouch(active);
        }
    }

    Winner CheckWinner()
    {
        MarkerType currentMarkerType;
        // 1. 가로체크
        for (int i = 0; i < rowColNum; i++)
        {
            // 비교를 위한 첫 번째 Cell
            Cell cell = cellList[rowColNum * i];
            int num = 0;
            currentMarkerType = cell.MarkerType;

            if (cell.MarkerType != currentMarkerType) continue;

            for (int j = 1; j < rowColNum; j++)
            {
                int index = i * rowColNum + j;
                if (cell.MarkerType == cellList[index].MarkerType)
                {
                    ++num;
                }
            }

            if (cell.MarkerType != MarkerType.None && num == rowColNum - 1)
            {
                if (currentMarkerType == MarkerType.Circle)
                    return Winner.Player;
                else
                    return Winner.Opponent;
            }
        }

        // 2. 세로체크
        for (int i = 0; i < rowColNum; i++)
        {
            Cell cell = cellList[i];
            int num = 0;
            if (cell.MarkerType != playerMakerType) continue;
            for (int j = 1; j < rowColNum; j++)
            {
                int index = j * rowColNum + i;
                if (cell.MarkerType == cellList[index].MarkerType)
                {
                    ++num;
                }
            }
            if (cell.MarkerType != MarkerType.None && num == rowColNum - 1)
            {
                return Winner.Player;
            }
        }

        // 3. 왼쪽 대각선 체크
        if (cellList[0].MarkerType == playerMakerType)
        {
            Cell cell = cellList[0];
            int num = 0;
            for (int i = 1; i < rowColNum; i++)
            {
                int index = i * rowColNum + i;
                if (cell.MarkerType == cellList[index].MarkerType)
                {
                    ++num;
                }
            }
            if (cell.MarkerType != MarkerType.None && num == rowColNum - 1)
            {
                return Winner.Player;
            }
        }

        // 4. 오른쪽 대각선 체크
        if (cellList[rowColNum - 1].MarkerType == playerMakerType)
        {
            Cell cell = cellList[rowColNum - 1];
            int num = 0;
            for (int i = 1; i < rowColNum; i++)
            {
                int index = i * rowColNum + rowColNum - i - 1;
                if (cell.MarkerType == cellList[index].MarkerType)
                {
                    ++num;
                }
            }
            if (cell.MarkerType != MarkerType.None && num == rowColNum - 1)
            {
                return Winner.Player;
            }
        }
        return Winner.None;
    }
}