using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AdventureGame
{
public class Zombie : MonoBehaviour
{
    [SerializeField] private Animator _animator;
        [SerializeField] private int _attackPower;
        [SerializeField] private float _distanceToFollowPlayer;
        [SerializeField] private float _distanceToAttackPlayer;
        [SerializeField] private float _speed;

        private PlayerMovement _playerMovement;
        private void Start()
        {
            _playerMovement = GameManager.Instance.PlayerManager.PlayerMovement;
        }

        private void Update()
        {

            if(Vector3.Distance(_playerMovement.transform.position, transform.position) < _distanceToAttackPlayer)
            {
                AttackPlayer();
            }

            else if(Vector3.Distance(_playerMovement.transform.position, transform.position)< _distanceToFollowPlayer)
            {
                FollowPlayer();
            }

            else
            {

            }
        }

        private void AttackPlayer()
        {
            _animator.SetTrigger("Attack");
            if (Vector3.Distance(_playerMovement.transform.position, transform.position) < _distanceToFollowPlayer)
                GameManager.Instance.PlayerManager.PlayerData.GetDamage(_attackPower);

        }

        private void FollowPlayer()
        {
            Vector3.MoveTowards(transform.position, _playerMovement.transform.position, _speed);
        }
    }
}

