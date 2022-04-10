using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GameManager : MonoBehaviour
{
     public GameObject[] _soldier;
    public GameObject[] _building;
    [SerializeField]  int _soldiercount=0;
    [SerializeField]  private bool _isgameactive= true;
    [SerializeField] int _gameactivecount = 0;
    [SerializeField] private GameObject _canvas;
    // Start is called before the first frame update
    void Start()
    {
        _building = GameObject.FindGameObjectsWithTag("building");
    }

    // Update is called once per frame
    void Update()
    {

       

        _soldier = GameObject.FindGameObjectsWithTag("soldier");
        if (_soldiercount == _soldier.Length)
        {

        }
        else
        {
            soldierdans();
            _soldiercount = _soldier.Length;
        }
        if (_soldier.Length == 6)
        {
            Time.timeScale = 0;
            _canvas.SetActive(true);
        }
    }

    private void soldierdans()
    {
        for (int i = 0; i < _soldier.Length; i++)
        {
            _soldier[i].GetComponent<Animator>().SetTrigger("danstrigger");
        }
    }

    


}
