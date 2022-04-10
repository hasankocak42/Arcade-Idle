using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stackfollow : MonoBehaviour
{
    public GameObject stack;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = stack.transform.position;
        transform.rotation = stack.transform.rotation;
    }
}
