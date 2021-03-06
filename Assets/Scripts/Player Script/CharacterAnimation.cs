using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimation : MonoBehaviour
{
    private Animator animator;
    
    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void Walk(bool move)
    {
        animator.SetBool(AnimationTags.MOVEMENT, move);
    }

    public void Punch_1(){
        animator.SetTrigger(AnimationTags.PUNCH_1_TRIGGER);
    }

    public void Punch_2(){
        animator.SetTrigger(AnimationTags.PUNCH_2_TRIGGER);
    }

    public void Punch_3(){
        animator.SetTrigger(AnimationTags.PUNCH_3_TRIGGER);
    }

    public void Kick_1(){
        animator.SetTrigger(AnimationTags.KICK_1_TRIGGER);
    }

    public void Kick_2(){
        animator.SetTrigger(AnimationTags.KICK_2_TRIGGER);
    }

    //Enemy Animations

    public void EnemyAttack(int attack){
        if(attack == 0){
            animator.SetTrigger(AnimationTags.ATTACK_1_TRIGGER);
        }
        if(attack == 1){
            animator.SetTrigger(AnimationTags.ATTACK_2_TRIGGER);            
        }
        if(attack == 2){
            animator.SetTrigger(AnimationTags.ATTACK_3_TRIGGER);            
        }
    }

    public void PlayIdleAnimation(){
        animator.Play(AnimationTags.IDLE_ANIMATION);
    }

    public void KnockDown(){
        animator.SetTrigger(AnimationTags.KNOCK_DOWN_TRIGGER);
    }

    public void StandUp(){
        animator.SetTrigger(AnimationTags.STAND_UP_TRIGGER);
    }

    public void Hit(){
        animator.SetTrigger(AnimationTags.HIT_TRIGGER);
    }

    public void Death(){
        animator.SetTrigger(AnimationTags.DEATH_TRIGGER);
    }
}
