using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.AI;


public class Enemy : MonoBehaviour
{
    // veriables
    float wanderRange = 5;
    float playerAttackRange = 6;
    float currentStateElapsed;
    float recoveryTime;
    // follow player
    public float sphereRadius; 
    //Atack player
    Rigidbody rb;
    public float lunge = 20f;
    //NavMesh
    NavMeshAgent agent;
    [SerializeField] Transform targetLocation;

    [SerializeField] FPSController player;
    public enum EneemyStates
    {
        wander,
        pursue,
        attack,
        recovery
    }
    [SerializeField] EneemyStates enemyStates;
    // Start is called before the first frame update
    void Start()
    {
       agent = GetComponent<NavMeshAgent>();

        
    }

    // Update is called once per frame
    void Update()
    {
        
        switch (enemyStates) 
        {
           case EneemyStates.wander:
                UpdateWander();
                break;

           case EneemyStates.pursue:
                UpdatePursue();
                break;

           case EneemyStates.attack:
                UpdateAttack();
                break;

           case EneemyStates.recovery:
                UpdateRecovery();
                break;

        }
    }
   
    void UpdateWander()
    {
        float distance = Vector3.Distance(transform.position, player.transform.position);
        if (distance < wanderRange)
        {
            enemyStates = EneemyStates.pursue;
        }
    }

    void UpdatePursue()
    {
        float distance = Vector3.Distance(transform.position, player.transform.position);
        if (distance > 5)
        {
            enemyStates = EneemyStates.wander;
        }
        if (distance < 4)
        {
            enemyStates = EneemyStates.attack;
        }
    }

    void UpdateAttack()
    {
        {
            rb.AddForce(transform.position * lunge);
            Debug.Log("Player was hit");
        }
    }
    void UpdateRecovery()
    {
        //if(they collided)
        {
            agent.enabled = false;
        }
    }
}
/* private void OnTriggerExit(Collider other)
 {
     switch (enemyStates)
     {
         case EneemyStates.pursue:

             break;
     }
 }
 private void OnTriggerEnter(Collider other)
 {
     switch (enemyStates) 
     {
         case EneemyStates.attack:

         break;
     }
 }
 private void OnTriggerStay(Collider other)
 {
     ;
 }

 {
     ;


     if (Physics.CheckSphere(transform.position, sphereRadius))
     {
         switch (enemyStates)
         {
             case EneemyStates.attack:

                 break;
         }
     }

 }
*/
