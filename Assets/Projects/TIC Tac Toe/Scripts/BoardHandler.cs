using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TICTacToe
{
    public class BoardHandler : MonoBehaviour
    {
        [SerializeField] public List<Box> Boxes;

        private void Start()
        {
            InitBoxesData();
        }

        public void CheckForWinner()
        {
            if (Boxes == null || Boxes.Count == 0)
                Debug.LogError("Borad Handler: No Boxes!");

            int turnCounter = GameManager.Instance.TurnHandler.TurnCounter;
            if (turnCounter>3)
            {
                int checkResult = CheckRows();
                if (checkResult > -1)
                {
                    GameManager.Instance.UIHandler.ActivateResultCanvas(checkResult);
                    return;
                }

                checkResult = CheckColumns();
                if (checkResult > -1)
                {
                    GameManager.Instance.UIHandler.ActivateResultCanvas(checkResult);
                    return;
                }

                checkResult = CheckDiagonals();
                if (checkResult > -1)
                {
                    GameManager.Instance.UIHandler.ActivateResultCanvas(checkResult);
                    return;
                }

                if(turnCounter== Boxes.Count-1)
                    GameManager.Instance.UIHandler.ActivateResultCanvas(checkResult);
            }
            GameManager.Instance.TurnHandler.ChangePlayerTurn();
        }

        #region Rows Checks

        private int CheckRows()
        {
            int rowCheck; //Beacuse 0 and 1 are the id of the players
            rowCheck = CheckUpperLine();
            if (rowCheck > -1)
                return rowCheck;

            rowCheck = CheckMiddleLine();
            if (rowCheck > -1)
                return rowCheck;

            rowCheck = CheckBottomLine();
            if (rowCheck > -1)
                return rowCheck;

            return rowCheck;
        }

        private int CheckUpperLine()
        {
            if (Boxes[0].PlayerIDSolder == Boxes[1].PlayerIDSolder && Boxes[1].PlayerIDSolder == Boxes[2].PlayerIDSolder && Boxes[0].PlayerIDSolder != -1)
                return Boxes[0].PlayerIDSolder;

            else
                return -1;
        }

        private int CheckMiddleLine()
        {
            if (Boxes[3].PlayerIDSolder == Boxes[4].PlayerIDSolder && Boxes[4].PlayerIDSolder == Boxes[5].PlayerIDSolder && Boxes[3].PlayerIDSolder != -1)
                return Boxes[3].PlayerIDSolder;

            else
                return -1;
        }

        private int CheckBottomLine()
        {
            if (Boxes[6].PlayerIDSolder == Boxes[7].PlayerIDSolder && Boxes[7].PlayerIDSolder == Boxes[8].PlayerIDSolder && Boxes[6].PlayerIDSolder!=-1)
                return Boxes[6].PlayerIDSolder;

            else
                return -1;
        }
        #endregion

        #region Columns Checks

        private int CheckColumns()
        {
            int rowCheck;
            rowCheck = CheckUpperLine();
            if (rowCheck > -1)
                return rowCheck;

            rowCheck = CheckMiddleLine();
            if (rowCheck > -1)
                return rowCheck;

            rowCheck = CheckBottomLine();
            if (rowCheck > -1)
                return rowCheck;

            return rowCheck;
        }

        private int CheckLefColumn()
        {
            if (Boxes[0].PlayerIDSolder == Boxes[3].PlayerIDSolder && Boxes[3].PlayerIDSolder == Boxes[6].PlayerIDSolder && Boxes[0].PlayerIDSolder != -1)
                return Boxes[0].PlayerIDSolder;

            else
                return -1;
        }

        private int CheckMiddleColumn()
        {
            if (Boxes[1].PlayerIDSolder == Boxes[4].PlayerIDSolder && Boxes[4].PlayerIDSolder == Boxes[7].PlayerIDSolder && Boxes[1].PlayerIDSolder != -1)
                return Boxes[1].PlayerIDSolder;

            else
                return -1;
        }

        private int CheckRightColumn()
        {
            if (Boxes[2].PlayerIDSolder == Boxes[5].PlayerIDSolder && Boxes[5].PlayerIDSolder == Boxes[8].PlayerIDSolder && Boxes[2].PlayerIDSolder != -1)
                return Boxes[2].PlayerIDSolder;

            else
                return -1;
        }
        #endregion

        #region Diagonals Check

        private int CheckDiagonals()
        {
            int diagonalCheck;
            diagonalCheck = CheckFirstDiagonal();
            if (diagonalCheck > -1)
                return diagonalCheck;

            diagonalCheck = CheckSecondDiagonal();
            if (diagonalCheck > -1)
                return diagonalCheck;

            return diagonalCheck;
        }

        private int CheckFirstDiagonal()
        {
            if (Boxes[0].PlayerIDSolder == Boxes[4].PlayerIDSolder && Boxes[4].PlayerIDSolder == Boxes[8].PlayerIDSolder && Boxes[0].PlayerIDSolder != -1)
                return Boxes[0].PlayerIDSolder;

            else
                return -1;
        }

        private int CheckSecondDiagonal()
        {
            if (Boxes[2].PlayerIDSolder == Boxes[4].PlayerIDSolder && Boxes[4].PlayerIDSolder == Boxes[6].PlayerIDSolder && Boxes[2].PlayerIDSolder != -1)
                return Boxes[2].PlayerIDSolder;

            else
                return -1;
        }
        #endregion

        private void OnDestroy()
        {
            for (int i = 0; i < Boxes.Count; i++)
            {
                Boxes[i].OnSoldierCreated -= CheckForWinner;
            }
        }

        private void InitBoxesData()
        {
            if (Boxes.Count == 0 || Boxes == null)
                Debug.LogError("BoardHandler: Fix the boxes");
            for (int i = 0; i < Boxes.Count; i++)
            {
                Boxes[i].SetBoxID(i);
                Boxes[i].OnSoldierCreated += CheckForWinner;
            }
        }
    }
}


