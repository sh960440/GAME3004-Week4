using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.AI;

[System.Serializable]
public enum EnemyState
{
    IDLE,
    RUN,
    JUMP,
    PUNCH,
    DIE
}

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(Animator))]
public class EnemyBehavior : MonoBehaviour
{
    public NavMeshAgent navMeshAgent;
    public PlayerBehavior player;
    public Animator controller;

    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        player = FindObjectOfType<PlayerBehavior>();
        controller = GetComponent<Animator>();

        if (controller)
        {
            controller.SetInteger("AnimState", (int)EnemyState.RUN);
        }     
    }

    // Update is called once per frame
    void Update()
    {
        if (player)
        {
            navMeshAgent.SetDestination(player.transform.position);

            var distance = Vector3.Distance(player.transform.position, transform.position);
            if ((controller) && (distance <= 3.0f))
            {
                //var direction = Vector3.Normalize(player.transform.position - transform.position);
                //transform.LookAt(player.transform.position - new Vector3(0.0f, 0.5f, 0.0f));
                controller.SetInteger("AnimState", (int)EnemyState.PUNCH);
            }
        }
    }
}
