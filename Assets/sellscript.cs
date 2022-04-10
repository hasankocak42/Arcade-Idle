using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sellscript : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;
    private float _time = 0;
    private float _delay = 0.05f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (_time <= Time.time )
            {
                _time = Time.time + _delay;
                Destroy(playerController._list[playerController._list.Count - 1], 0.1f);
                playerController.stacked();


            }
        }
    }
}
