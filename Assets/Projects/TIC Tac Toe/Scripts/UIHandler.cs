using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TICTacToe
{
    public class UIHandler : MonoBehaviour
    {
        [SerializeField] GameObject _winnerCanvas;
        [SerializeField] Image _winnerSprite;

        [SerializeField] GameObject _indicatorCanvas;
        [SerializeField] Image _indicatorSprite;

        private void Start()
        {
            GameManager.Instance.TurnHandler.OnPlayerTurnChanged += UpdateIndicator;
        }

        public void ActivateResultCanvas(int result)
        {
            _indicatorCanvas.SetActive(false);
            _winnerSprite.sprite = GameManager.Instance.VisualHandler.GetSprite(result);
            _winnerCanvas.gameObject.SetActive(true);
        }

        public void UpdateIndicator(int playerIDTurn)
        {
            _indicatorSprite.sprite = GameManager.Instance.VisualHandler.GetSprite(playerIDTurn);
        }
    }
}

