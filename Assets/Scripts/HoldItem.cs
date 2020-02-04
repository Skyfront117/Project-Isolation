using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldItem : MonoBehaviour
{
    public GameObject ball;
    public Transform guide;
    private bool picked;
    // Start is called before the first frame update
    void Start()
    {
        picked = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            if(/*ball.transform.position - guide.transform.position == new Vector3(5, 5, 0) && */picked == false)
            {
                ball.transform.SetParent(guide);
                ball.transform.localRotation = transform.rotation;
                ball.transform.position = guide.position;
                picked = true;
            }else if(picked == true)
            {
                guide.GetChild(0).transform.position = guide.transform.position;
                guide.GetChild(0).parent = null;
                picked = false;
            }
            else
            {
                return;
            }
            
        }
    }
}
