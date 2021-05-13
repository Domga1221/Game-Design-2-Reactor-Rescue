using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{

    public Animator animator;

    public AnimatorStateInfo animatorStateInfo;

    public int currentState;

    public Conductor conductor;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        animatorStateInfo = animator.GetCurrentAnimatorStateInfo(0);
        currentState = animatorStateInfo.fullPathHash;
    }

    // Update is called once per frame
    void Update()
    {
        animator.Play(currentState, -1, conductor.songPositionInBeats % 1);
        //Set the speed to 0 so it will only change frames when you next update it
        animator.speed = 0;
    }
}
