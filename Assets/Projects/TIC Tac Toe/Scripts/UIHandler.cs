using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TICTacToe
{
    public class UIHandler : MonoBehaviour
    {
        [SerializeField] Canvas canvas;
        [SerializeField] Sprite winnerSprite;
        public void ActivateResultCanvas(int result)
        {
            winnerSprite = GameManager.Instance.VisualHandler.GetSprite(GameManager.Instance.TurnHandler.PlayerIDTurn);
            canvas.gameObject.SetActive(true);
        }
     
    }
}

