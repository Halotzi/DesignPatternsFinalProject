using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TICTacToe
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance => _instance;
        private static GameManager _instance;

        [SerializeField] VisualHandler _visualHandler;
        [SerializeField] TurnHandler _turnHandler;
        [SerializeField] UIHandler _uiHandler;

        public UIHandler UIHandler => _uiHandler;
        public VisualHandler VisualHandler => _visualHandler;
        public TurnHandler TurnHandler => _turnHandler;

        private void Awake()
        {
            _instance = this;
        }

        private void Start()
        {
            _turnHandler.RandomStarter();
        }
    }
}


