using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    public enum ComboState {
        NONE,
        PUNCH_1,
        PUNCH_2,
        PUNCH_3,
        KICK_1,
        KICK_2
    }

    private CharacterAnimation playerAnimation;
    private bool activateTimerToReset;
    
    private float defaultComboTimer = 0.4f;
    private float currentComboTimer;

    private ComboState currentComboState;

	void Awake() 
	{
		playerAnimation = GetComponentInChildren<CharacterAnimation>();
        currentComboTimer = defaultComboTimer;
        currentComboState = ComboState.NONE;
	}


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ComboAttacks();
        ResetComboState();
    }

    void ComboAttacks()
    {
        if(Input.GetKeyDown(KeyCode.Z))
        {
            if(currentComboState == ComboState.PUNCH_3 ||
                currentComboState == ComboState.KICK_1 ||
                currentComboState == ComboState.KICK_2
            )
            {
                return;
            }

            currentComboState++;
            activateTimerToReset = true;
            currentComboTimer = defaultComboTimer;

            if(currentComboState == ComboState.PUNCH_1)
            {
                playerAnimation.Punch_1();
            }
            
            if(currentComboState == ComboState.PUNCH_2)
            {
                playerAnimation.Punch_2();
            }

            if(currentComboState == ComboState.PUNCH_3)
            {
                playerAnimation.Punch_3();
            }
        }

        if(Input.GetKeyDown(KeyCode.X))
        {
            // C P3 K2
            if(currentComboState == ComboState.PUNCH_3 || 
                currentComboState == ComboState.KICK_2)
            {
                return;
            }

            // C N P1 P2
            if(currentComboState == ComboState.NONE || 
                currentComboState == ComboState.PUNCH_1 ||
                currentComboState == ComboState.PUNCH_2)
            {
                currentComboState = ComboState.KICK_1;
            }
            else if (currentComboState == ComboState.KICK_1)
            {
                currentComboState ++;
            }
            

            activateTimerToReset = true;
            currentComboTimer = defaultComboTimer;

            if(currentComboState == ComboState.KICK_1)
            {
                playerAnimation.Kick_1();
            }
            
            if(currentComboState == ComboState.KICK_2)
            {
                playerAnimation.Kick_2();
            }


        }

    }


    void ResetComboState()
    {
        currentComboTimer -= Time.deltaTime;
        if(currentComboTimer <= 0f)
        {
            currentComboState = ComboState.NONE;

            activateTimerToReset = false;
            currentComboTimer = defaultComboTimer; // <---------------
        }
    }   
}
