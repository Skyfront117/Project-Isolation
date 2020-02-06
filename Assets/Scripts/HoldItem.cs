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
        //solo coge y deja el objeto queda comparar la posicion del objeto respecto a la del jugador
        if(Input.GetKeyDown(KeyCode.E))
        {
            if(picked == false)
            {
                ball.transform.SetParent(guide);
                ball.transform.localRotation = transform.rotation;
                ball.transform.position = guide.position;
                picked = true;
            }else if(picked == true)
            {
                //deberia dejar el objeto en la posicion del jugador pero no funciona bien solo a veces lo hace
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
