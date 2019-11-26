using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    // Start is called before the first frame update
    PlayerMovements Cat;
    void Start()
    {
        Cat = gameObject.transform.GetChild(4).GetComponent<PlayerMovements>();
    }

    // Update is called once per frame
    void Update()
    {   if(!Cat.isDead)
            transform.Translate(0, 0, 0.2f);
    }
}
