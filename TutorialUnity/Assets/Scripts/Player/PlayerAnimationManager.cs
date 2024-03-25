using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationManager : MonoBehaviour
{
    [Header("�ִϸ��̼� ���� ����")]
    private Animator animator;

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
    }

    public void SetAttack()
    {
        animator.SetTrigger("doAttack");
    }
}
