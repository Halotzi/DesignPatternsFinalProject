using UnityEngine;
using System;

namespace TICTacToe
{
    public class Box : MonoBehaviour
    {
        public event Action OnSoldierCreated;

        [SerializeField] private SpriteRenderer _spriteRenderer;
        private int _playerIDSoldier;
        private int _boxID;

        public int GetBoxID() { return _boxID; }
        public void SetBoxID(int boxID) { _boxID = boxID; }

        public int PlayerIDSolder => _playerIDSoldier;

        private void Awake()
        {
            _playerIDSoldier = -1;
        }

        private void OnMouseDown()
        {
            if (_spriteRenderer.sprite == null && _boxID!=-1)
            {
                GameManager.Instance.Momento.AddUndo(DuplicateBox());
                CreateSoldier();
                if (OnSoldierCreated != null)
                    OnSoldierCreated.Invoke();
            }
        }

        private void CreateSoldier()
        {
            _playerIDSoldier = GameManager.Instance.TurnHandler.PlayerIDTurn;
            _spriteRenderer.sprite = GameManager.Instance.VisualHandler.GetSprite(GameManager.Instance.TurnHandler.PlayerIDTurn);
        }

        public void ResetSoilder()
        {
            _playerIDSoldier = -1;
            _spriteRenderer.sprite = null;
        }

        public DuplicatedBox DuplicateBox()
        {
            DuplicatedBox duplicatedBox = new DuplicatedBox(_spriteRenderer.sprite, _playerIDSoldier, _boxID);
            return duplicatedBox;
        }

        public void InsertDuplicateData(DuplicatedBox duplicatedBox)
        {
            _spriteRenderer.sprite = duplicatedBox.Sprite;
            _playerIDSoldier = duplicatedBox.PlayerIDSoldier;
            _boxID = duplicatedBox.BoxID;
        }
    }


}

namespace TICTacToe
{
    public class DuplicatedBox
    {
        public Sprite Sprite;
        public int PlayerIDSoldier;
        public int BoxID;

        public DuplicatedBox(Sprite SpriteRenderer, int PlayerIDSoldier, int BoxID)
        {
            this.Sprite = SpriteRenderer;
            this.PlayerIDSoldier = PlayerIDSoldier;
            this.BoxID = BoxID;
        }
    }
}
