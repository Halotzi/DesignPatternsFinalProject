using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TICTacToe
{
    public class Momento : MonoBehaviour
    {
        Stack<DuplicatedBox> _undo = new Stack<DuplicatedBox>();
        Stack<DuplicatedBox> _redo = new Stack<DuplicatedBox>();

        public void Undo()
        {
            if(_undo.Count!=0)
            {
                DuplicatedBox undoBox = _undo.Pop();
                DuplicatedBox redoBox = GameManager.Instance.BoardHandler.Boxes[undoBox.BoxID].DuplicateBox();
                GameManager.Instance.BoardHandler.Boxes[undoBox.BoxID].InsertDuplicateData(undoBox);
                _redo.Push(redoBox);
                GameManager.Instance.TurnHandler.ChangePlayerTurn(true);
            }
        }

        public void Redo()
        {
            if (_redo.Count != 0)
            {
                DuplicatedBox redoBox = _redo.Pop();
                DuplicatedBox undoBox = GameManager.Instance.BoardHandler.Boxes[redoBox.BoxID].DuplicateBox();
                GameManager.Instance.BoardHandler.Boxes[redoBox.BoxID].InsertDuplicateData(redoBox);
                _undo.Push(undoBox);
            }
        }

        public void AddUndo(DuplicatedBox lastUsedBox)
        {
            _undo.Push(lastUsedBox);
        }

        public void ResetRedo()
        {
            if(_redo.Count>0)
            _redo.Clear();
        }
    }
}
