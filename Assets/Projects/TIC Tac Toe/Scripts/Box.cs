using UnityEngine;

namespace TICTacToe
{
    public class Box : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _spriteRenderer;
        private int _playerIDSolder;
        private int _boxID;

        public void SetBoxID(int boxID) { _boxID = boxID; }

        public int PlayerIDSolder => _playerIDSolder;

        private void OnMouseDown()
        {
            if (_spriteRenderer.sprite == null)
            {
                CreateSoilder();
                GameManager.Instance.TurnHandler.ChangePlayerTurn();
            }
        }

        private void CreateSoilder()
        {
            _playerIDSolder = GameManager.Instance.TurnHandler.PlayerIDTurn;
            _spriteRenderer.sprite = GameManager.Instance.VisualHandler.GetSprite(GameManager.Instance.TurnHandler.PlayerIDTurn);
        }

        public void ResetSoilder()
        {
            _playerIDSolder = -1;
            _spriteRenderer.sprite = null;
        }
    }
}

