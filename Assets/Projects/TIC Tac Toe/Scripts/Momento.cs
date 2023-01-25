using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TICTacToe
{
    public class Momento : MonoBehaviour
    {
        Stack<Box> _undo = new Stack<Box>();
        Stack<Box> _redo = new Stack<Box>();

        public void Undo()
        {
            if(_undo.Count!=0)
            {
                Box undoBox = _undo.Pop();
                Box redoBox = GameManager.Instance.BoardHandler.Boxes[undoBox.GetBoxID()];
                GameManager.Instance.BoardHandler.Boxes[undoBox.GetBoxID()] = undoBox;
                _redo.Push(redoBox);
            }
        }

        public void Redo()
        {
            if (_redo.Count != 0)
            {
                Box redoBox = _redo.Pop();
                Box undoBox = GameManager.Instance.BoardHandler.Boxes[redoBox.GetBoxID()];
                GameManager.Instance.BoardHandler.Boxes[redoBox.GetBoxID()] = redoBox;
                _undo.Push(undoBox);
            }

        }

        public void AddUndo(Box lastUsedBox)
        {
            _undo.Push(lastUsedBox);
        }

        public void ResetRedo()
        {
            _redo.Clear();
        }
    }
}
