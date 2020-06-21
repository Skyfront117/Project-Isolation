using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlertIndicator : MonoBehaviour
{
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.alert)
        {
            if (!animator.GetBool("Alert"))
            {
                animator.SetBool("Alert", true);
                SoundManager.Instance.PlayAlertOn();
            }
        }
        else
        {
            if (animator.GetBool("Alert"))
            {
                animator.SetBool("Alert", false);
                SoundManager.Instance.PlayAlertOff();
            }
        }
    }
}
