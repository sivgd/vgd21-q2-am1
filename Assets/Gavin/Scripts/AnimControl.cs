using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimControl : MonoBehaviour
{
    Animator animator;
    string idleName;
    string shootingName;
    Tower towerScript;
    // Start is called before the first frame update
    void Start()
    {
        towerScript = gameObject.GetComponent<Tower>();
        animator = gameObject.GetComponent<Animator>();
        idleName = "Idle";
        shootingName = "Shoot";
        animator.Play(idleName);
        animator.speed =  1.833f / towerScript.shootingSpeed;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetAnimator()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    public void ShootAnim(bool isShooting)
    {
        if (isShooting)
        {
            animator.Play(shootingName);
        }
        else
        {
            animator.Play(idleName);
        }
    }
}
