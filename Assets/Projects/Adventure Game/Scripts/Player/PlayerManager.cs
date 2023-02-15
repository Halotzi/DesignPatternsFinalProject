using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AdventureGame
{

public class PlayerManager : MonoBehaviour
{
        [SerializeField] private PlayerMovement _playerMovement;
        [SerializeField] private PlayerData _playerData;

        public PlayerMovement PlayerMovement => _playerMovement;
        public PlayerData PlayerData => _playerData;

    }
}
