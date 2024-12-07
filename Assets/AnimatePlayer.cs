using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatePlayer : MonoBehaviour
{
    
    private Animator animator;
    private TopDownCC playerCC;
    
    
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        playerCC = GetComponent<TopDownCC>();
    }

    // Update is called once per frame
    void Update()
    {
        SetAnimationPeramaters();
    }


    private void SetAnimationPeramaters()
    {
        Vector2 direction = playerCC.GetMoveVector();

        
        //isMoving(direction);
        SetXinput(direction.x);
        SetYinput(direction.y);
        
        
        
        
        
    }

    private void SetXinput(float input)
    {
        animator.SetFloat("xInput", input);
    }
    
    private void SetYinput(float input)
    {
        animator.SetFloat("yInput", input);
    }

    private void isMoving(Vector2 moveVector)
    {
        if (moveVector != Vector2.zero)
        {
            animator.SetBool("IsMoving", true);
            
        }
        animator.SetBool("IsMoving", false);
        
    }
    
    
    
}
