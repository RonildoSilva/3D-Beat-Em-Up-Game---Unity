using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private CharacterAnimation enemyAnimation;
    private Rigidbody enemyBody;

    public float speed = 1.3f;

    private Transform playerTarget;

    private float attackDistance = 1.8f;
    private float chasePlayerAfterAttack = 1f;

    private float curentAttackTime;
    private float defaultAttackTime = 2f;

    private bool followPlayer;
    private bool attackPlayer;

    void Awake()
    {
        enemyAnimation = GetComponentInChildren<CharacterAnimation>();
        enemyBody = GetComponent<Rigidbody>();

        playerTarget = GameObject.FindWithTag(Tags.PLAYER_TAG).transform;
    }

    // Start is called before the first frame update
    void Start()
    {
        followPlayer = true;
        curentAttackTime = defaultAttackTime;
    }

    // Update is called once per frame
    void Update()
    {
        Attack();
    }

    void FixedUpdate(){
        FollowTarget();
    }

    void FollowTarget()
    {
        if(!followPlayer){
            return;
        }else{
            if(Vector3.Distance(transform.position, playerTarget.position) > attackDistance){

                transform.LookAt(playerTarget);
                enemyBody.velocity = transform.forward * speed;

                if(enemyBody.velocity.sqrMagnitude != 0){
                    enemyAnimation.Walk(true);
                }

            }//else if(Vector3.Distance(transform.position, playerTarget.position) <= attackDistance){
            else{
                enemyBody.velocity = Vector3.zero;
                enemyAnimation.Walk(false);

                followPlayer = false;
                attackPlayer = true;
            }
        }
    }

    void Attack(){
        if(!attackPlayer){
            return;
        }else{
            curentAttackTime += Time.deltaTime;

            if(curentAttackTime > defaultAttackTime){

                enemyAnimation.EnemyAttack(Random.Range(0,3));
                curentAttackTime = 0f;
            }

            if(Vector3.Distance(transform.position, playerTarget.position) > 
                attackDistance + chasePlayerAfterAttack){

                attackPlayer = false;
                followPlayer = true;
            }
        }
    }
}
