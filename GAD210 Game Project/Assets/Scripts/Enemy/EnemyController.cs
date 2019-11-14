using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyController : MonoBehaviour
{
    public float lookRadius = 2.0f;
    public Transform[] moveSpots;
    private int _currentMovePoint;
    private float _waitTime;
    public float startWaitTime;
    public float rotationTime = 1f;

    private Transform _playerTarget;
    private NavMeshAgent _agent;
    private Animator _animator;
    private LevelReset _levelReset;
    private bool _hitPlayer = false;
    private PlayerManager _playerManager;

    public float speedSmoothTime;

    public float stoppingDistance = 0.7f;

    // Start is called before the first frame update
    void Start()
    {
        _waitTime = startWaitTime;
        _agent = GetComponent<NavMeshAgent>();
        _animator = transform.GetChild(0).GetComponent<Animator>();
        _levelReset = FindObjectOfType<LevelReset>();
        _playerManager = FindObjectOfType<PlayerManager>();
        _playerTarget = _playerManager.player.transform;
    }


    // Update is called once per frame
    void Update()
    {
        float animationSpeedPercent;
        float distance = 5.0f;
        if (_playerTarget == null)
        {
            _playerTarget = _playerManager.player.transform;
        }
        else
        {
            distance = Vector3.Distance(transform.position, _playerTarget.position);

        }

        if (distance <= lookRadius)
        {
            
            _agent.SetDestination(_playerTarget.position);
            _agent.speed = 2;
            if (distance < stoppingDistance)
            {
                animationSpeedPercent = 0f;
                _animator.SetFloat("speedPercent", animationSpeedPercent, speedSmoothTime, Time.deltaTime);
                FaceTarget(_agent.destination);
                if(!_hitPlayer)
                {
                    _levelReset.EnemyReset();
                    _hitPlayer = true;
                }

            }
            else
            {
                animationSpeedPercent = 2f;
                _animator.SetFloat("speedPercent", animationSpeedPercent, speedSmoothTime, Time.deltaTime);
            }
            
        }
        else
        {
            if (moveSpots.Length > 0)
            {
                _agent.SetDestination(moveSpots[_currentMovePoint].position);
                FaceTarget(_agent.destination);
                _agent.speed = 1;
                if (Vector3.Distance(transform.position, _agent.destination) < 0.7f)
                {
                    if (_waitTime <= 0)
                    {
                        _currentMovePoint++;
                        if (_currentMovePoint > moveSpots.Length - 1)
                        {
                            _currentMovePoint = 0;
                        }
                        _waitTime = startWaitTime;
                    }
                    else
                    {
                        _waitTime -= Time.deltaTime;
                        animationSpeedPercent = 0f;
                        _animator.SetFloat("speedPercent", animationSpeedPercent, speedSmoothTime, Time.deltaTime);
                    }
                }
                else
                {
                    animationSpeedPercent = 1f;
                    _animator.SetFloat("speedPercent", animationSpeedPercent, speedSmoothTime, Time.deltaTime);
                }
            }
            else
            {
                _agent.SetDestination(transform.position);
            }
            

        }
        
    }

    private void FaceTarget(Vector3 target)
    {
        Vector3 direction = (target - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * rotationTime);
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}
