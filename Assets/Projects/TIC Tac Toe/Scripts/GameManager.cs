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
        [SerializeField] UIHandler _uiHandler;
        [SerializeField] Momento _momento;
        [SerializeField] BoardHandler _boardHandler;

        public UIHandler UIHandler => _uiHandler;
        public BoardHandler BoardHandler => _boardHandler;
        public VisualHandler VisualHandler => _visualHandler;
        public TurnHandler TurnHandler => _turnHandler;
        public Momento Momento => _momento;

        private TurnHandler _turnHandler;

        private void Awake()
        {
            _instance = this;
            _turnHandler = new TurnHandler();
        }

        private void Start()
        {
            _turnHandler.RandomStarter();
        }
    }
}


