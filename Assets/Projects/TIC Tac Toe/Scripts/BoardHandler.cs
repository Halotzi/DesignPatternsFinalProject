using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TICTacToe
{
    public class BoardHandler : MonoBehaviour
    {
        [SerializeField] List<Box> _boxes;

        private void Start()
        {
            for (int i = 0; i < _boxes.Count; i++)
            {
                _boxes[i].SetBoxID(i);
            }
        }

        public void CheckForWinner()
        {
            if (_boxes == null || _boxes.Count == 0)
                Debug.LogError("Borad Handler: No Boxes!");

            int turnCounter = GameManager.Instance.TurnHandler.TurnCounter;
            if (turnCounter>4)
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

                if(turnCounter==9)
                    GameManager.Instance.UIHandler.ActivateResultCanvas(checkResult);
            }

            
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
            if (_boxes[0].PlayerIDSolder == _boxes[1].PlayerIDSolder && _boxes[1].PlayerIDSolder == _boxes[2].PlayerIDSolder)
                return _boxes[0].PlayerIDSolder;

            else
                return -1;
        }

        private int CheckMiddleLine()
        {
            if (_boxes[3].PlayerIDSolder == _boxes[4].PlayerIDSolder && _boxes[4].PlayerIDSolder == _boxes[5].PlayerIDSolder)
                return _boxes[3].PlayerIDSolder;

            else
                return -1;
        }

        private int CheckBottomLine()
        {
            if (_boxes[6].PlayerIDSolder == _boxes[7].PlayerIDSolder && _boxes[7].PlayerIDSolder == _boxes[8].PlayerIDSolder)
                return _boxes[6].PlayerIDSolder;

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
            if (_boxes[0].PlayerIDSolder == _boxes[3].PlayerIDSolder && _boxes[3].PlayerIDSolder == _boxes[6].PlayerIDSolder)
                return _boxes[0].PlayerIDSolder;

            else
                return -1;
        }

        private int CheckMiddleColumn()
        {
            if (_boxes[1].PlayerIDSolder == _boxes[4].PlayerIDSolder && _boxes[4].PlayerIDSolder == _boxes[7].PlayerIDSolder)
                return _boxes[1].PlayerIDSolder;

            else
                return -1;
        }

        private int CheckRightColumn()
        {
            if (_boxes[2].PlayerIDSolder == _boxes[5].PlayerIDSolder && _boxes[5].PlayerIDSolder == _boxes[8].PlayerIDSolder)
                return _boxes[2].PlayerIDSolder;

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
            if (_boxes[0].PlayerIDSolder == _boxes[4].PlayerIDSolder && _boxes[4].PlayerIDSolder == _boxes[8].PlayerIDSolder)
                return _boxes[0].PlayerIDSolder;

            else
                return -1;
        }

        private int CheckSecondDiagonal()
        {
            if (_boxes[2].PlayerIDSolder == _boxes[4].PlayerIDSolder && _boxes[4].PlayerIDSolder == _boxes[6].PlayerIDSolder)
                return _boxes[2].PlayerIDSolder;

            else
                return -1;
        }
        #endregion
    }
}


