using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyPatrol : MonoBehaviour
{
    public NavMeshAgent navMeshAgent;
    public float startWaitTime = 4;
    public float timeToRotate =2;
    public float speedWalk = 6;
    public float speedrun = 9;

    public float viewRadius = 15;
    public float viewAngle = 90;
    public LayerMask playerMask;
    public float meshResolution = 1f;
    public int endgeIterations = 4;
    public float edgeDistance = 0.5f;

    public Transform[] waypoints;
    int _CurrentWaypointIndex;

    Vector3 playerLastPos = Vector3.zero;
    Vector3 _PlayerPos;

    float _waitTime;
    float _TimeToRotate;
    bool _PlayerInRange;
    bool _PlayerNear;
    bool _IsPatrol;
    bool _CaughtPlayer;

    void Start()
    {
        _PlayerPos = Vector3.zero;
        _IsPatrol = true;
        _CaughtPlayer = false;
        _PlayerInRange = false;
        _waitTime = startWaitTime;
        _TimeToRotate = timeToRotate;

        _CurrentWaypointIndex = 0;
        navMeshAgent = GetComponent<NavMeshAgent>();

        navMeshAgent.isStopped = false;
        navMeshAgent.speed = speedWalk;
        navMeshAgent.SetDestination(waypoints[_CurrentWaypointIndex].position);
    }

    void Update()
    {
        EnviromentView();
        
        if(!_IsPatrol)
        {
            Chasing();
        }
        else
        {
            Patroling();
        }
    }
    private void Patroling()
    {
        if(_PlayerNear)
        {
            if(_TimeToRotate <= 0)
            {
                Move(speedWalk);
                LookingPlayer(playerLastPos);
            }
            else
            {
                Stop();
                _TimeToRotate -= Time.deltaTime;
            }
        }
        else
        {
            _PlayerNear = false;
            playerLastPos = Vector3.zero;
            navMeshAgent.SetDestination(waypoints[_CurrentWaypointIndex].position);
            if(navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance)
            {
                if(_waitTime <= 0)
                {
                    NextPoint();
                    Move(speedWalk);
                    _waitTime = startWaitTime;
                }
            }
        }
    }

    private void Chasing()
    {
        _PlayerNear = false;
        playerLastPos = Vector3.zero;

        if(!_CaughtPlayer)
        {
            Move(speedWalk);
            navMeshAgent.SetDestination(_PlayerPos);
        }
        if(navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance)
        {
            if(_waitTime <= 0 && !_CaughtPlayer && Vector3.Distance(transform.position, GameObject.FindGameObjectWithTag("Player").transform.position) <= 6f)
            {
                _IsPatrol = true;
                _PlayerNear = false;
                _TimeToRotate = timeToRotate;
                _waitTime = startWaitTime;
                navMeshAgent.SetDestination(waypoints[_CurrentWaypointIndex].position);
            }
            else
            {
                if (Vector3.Distance(transform.position, GameObject.FindGameObjectWithTag("Player").transform.position)>= 2.5f)
                {
                    Stop();
                    _waitTime = Time.deltaTime;

                }
                    
            }
        }
    }
    void Move(float speed)
    {
        navMeshAgent.isStopped = false;
        navMeshAgent.speed = speed;
    }
    void Stop()
    {
        navMeshAgent.isStopped = true;
        navMeshAgent.speed = 0;
    }
    void NextPoint()
    {
        _CurrentWaypointIndex = (_CurrentWaypointIndex + 1) % waypoints.Length;
        navMeshAgent.SetDestination(waypoints[_CurrentWaypointIndex].position);
    }
    void CaughtPlayer()
    {
        _CaughtPlayer = true;
    }
    void LookingPlayer(Vector3 player)
    {
        navMeshAgent.SetDestination(player);
        if (Vector3.Distance(transform.position, player) <= 0.3)
        {
            if(_waitTime <= 0)
            {
                _PlayerNear = false;
                Move(speedWalk);
                navMeshAgent.SetDestination(waypoints[_CurrentWaypointIndex].position);
                _waitTime = startWaitTime;
                _TimeToRotate = timeToRotate;

            }
            else
            {
                Stop();
                _waitTime -= Time.deltaTime;
            }
        }
        //void EnviromentView()
        //{
        //    Collider[] playerInRange = Physics.OverlapSphere(transform.position, viewRadius, playerMask);
        //    for(int i = 0; i < playerInRange.Length; i++)
        //    {
        //        Transform player = playerInRange[i].transform;
        //        Vector3 dirToPlayer = (player.position - transform.position).normalized;
        //        if (Vector3.Angle(transform.forward, dirToPlayer) < viewAngle / 2) 
        //        {
        //            float distToPlayer = Vector3.Distance(transform.position, player.position);
        //            if(!Physics.Raycast(transform.position, dirToPlayer , distToPlayer ))
        //            {
        //                _PlayerInRange = true;
        //                _IsPatrol = false;
        //            }
        //            else
        //            {
        //                _PlayerInRange = false;
        //            }
        //        }
        //        if(Vector3.Distance(transform.position, player.position)> viewRadius)
        //        {
        //            _PlayerInRange = false;
        //        }
        //    }
        //    if(_PlayerInRange)
        //    {
        //        _PlayerPos = Player.transform.position;
        //    }
        //}
    }
    void EnviromentView()
    {
        Collider[] playerInRange = Physics.OverlapSphere(transform.position, viewRadius, playerMask);
        for (int i = 0; i < playerInRange.Length; i++)
        {
            Transform player = playerInRange[i].transform;
            Vector3 dirToPlayer = (player.position - transform.position).normalized;
            if (Vector3.Angle(transform.forward, dirToPlayer) < viewAngle / 2)
            {
                float distToPlayer = Vector3.Distance(transform.position, player.position);
                if (!Physics.Raycast(transform.position, dirToPlayer, distToPlayer))
                {
                    _PlayerInRange = true;
                    _IsPatrol = false;
                }
                else
                {
                    _PlayerInRange = false;
                }
            }
            if (Vector3.Distance(transform.position, player.position) > viewRadius)
            {
                _PlayerInRange = false;
            }
        }
        if (_PlayerInRange)
        {
          //  _PlayerPos = Player.transform.position;
        }
    }
}
