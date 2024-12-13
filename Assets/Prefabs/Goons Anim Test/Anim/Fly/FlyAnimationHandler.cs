using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FlyAnimationHandler : MonoBehaviour
{
    [SerializeField] private Animator animator;
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
        if (!stateInfo.IsName("Fly_Attack"))
        {
            animator.ResetTrigger("Attack1");
        }
        if (!stateInfo.IsName("Fly_Attack2"))
        {
            animator.ResetTrigger("Attack2");
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

    }
}
