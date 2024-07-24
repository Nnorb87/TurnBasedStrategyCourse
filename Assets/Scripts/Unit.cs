using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Unit : MonoBehaviour
{
    [SerializeField] private Animator unitAnimator;
    private Vector3 targetPosition;

    private void Update(){


        float stoppingDistance = .1f;
        if ( Vector3.Distance(transform.position, targetPosition) > stoppingDistance){
            Vector3 moveDirection = (targetPosition - transform.position).normalized;
            float moveSpeed = 4f;
            transform.position += moveDirection * Time.deltaTime * moveSpeed;
            unitAnimator.SetBool("isWalking", true);
        }   else {
                    unitAnimator.SetBool("isWalking", false);
        }

        if (Input.GetMouseButtonDown(0)){
            Move(MouseWorld.GetPosition());
        }
    }

    private void Move(Vector3 targetPosition){
        this.targetPosition = targetPosition;
    }

}
