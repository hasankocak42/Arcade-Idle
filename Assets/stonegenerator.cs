using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stonegenerator : MonoBehaviour
{
    public GameObject _stone;
    public PlayerController _playercontrol;
    public Transform _stonecreator;
    [SerializeField] private float _time;
    [SerializeField] private float _delay = 0.2f;

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
        if (other.gameObject.tag == "Player" && _time <= Time.time)
        {
            _time = Time.time + _delay;
            GameObject stone = Instantiate(_stone, _stonecreator);
            _playercontrol.Addstack(stone);
        }
    }
    
}
