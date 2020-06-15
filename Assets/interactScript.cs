using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class interactScript : MonoBehaviour
{
    public static interactScript instance { get; private set; }
    public bool canInteract;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        canInteract = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (canInteract)
        {
            GetComponent<Text>().text = "E TO INTERACT";
        }
        else
        {
            GetComponent<Text>().text = "";
        }
    }
}
