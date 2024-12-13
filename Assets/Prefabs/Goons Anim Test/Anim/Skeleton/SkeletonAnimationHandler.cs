using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonAnimationHandler : MonoBehaviour
{
    [SerializeField] private Animator animator;


    //This hp is for testing purposes
    int hp = 3;

    // Start is called before the first frame update
    void Start()
    {
        animator.SetInteger("HP", hp);
    }

    // Update is called once per frame
    void Update()
    {
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
        if (!stateInfo.IsName("Skeleton_Attack"))
        {
            animator.ResetTrigger("Attack1");
        }
        if (!stateInfo.IsName("Skeleton_Attack2"))
        {
            animator.ResetTrigger("Attack2");
        }
        if (!stateInfo.IsName("Skeleton_Damage"))
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

        if (hp == 0)
        {
            hp = 3;
        }
    }
}
