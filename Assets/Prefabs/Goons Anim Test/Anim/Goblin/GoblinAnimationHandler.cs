using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinAnimationHandler : MonoBehaviour
{

    [SerializeField] private Animator animator;


    //This hp is for testing purposes
    int hp = 3;

    bool moving=false;

    // Start is called before the first frame update
    void Start()
    {
        animator.SetInteger("HP", hp);
        animator.SetBool("Moving", moving);
    }

    // Update is called once per frame
    void Update()
    {
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
        if (!stateInfo.IsName("Goblin_Attack"))
        {
            animator.ResetTrigger("Attack1");
        }
        if (!stateInfo.IsName("Goblin_Attack2"))
        {
            animator.ResetTrigger("Attack2");
        }
        if (!stateInfo.IsName("Goblin_Damage"))
        {
            animator.ResetTrigger("TakeDMG");
        }


        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            animator.SetTrigger("Attack1");
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            animator.SetTrigger("Attack2");
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            hp--;
            animator.SetInteger("HP", hp);
            animator.SetTrigger("TakeDMG");
        }
        moving=false;
        if (Input.GetKey(KeyCode.LeftShift))
        {
            moving = true;
        }
        animator.SetBool("Moving", moving);



        if (hp == 0)
        {
            hp = 3;
        }
    }
}

