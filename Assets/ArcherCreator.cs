using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class ArcherCreator : MonoBehaviour
{

    [SerializeField] private PlayerController playerController;
    [SerializeField] private GameObject _destroyed;

    private float _woodcount = 0;
    private float _goldcount = 0;
    private float _stonecount = 0;

    private float _targetwood;
    private float _targetgold;
    private float _targetstone;

    [SerializeField] private bool _isneedwood = true;
    [SerializeField] private bool _isneedgold = true;
    [SerializeField] private bool _isneedstone = true;
    [SerializeField] private bool _isbuild = false;
    public bool _isneedarcher = true;
    private int i = 1;
    private float _time = 0;
    private float _delay = 0.2f;

    [SerializeField] private TextMeshProUGUI _textwood;
    [SerializeField] private TextMeshProUGUI _textgold;
    [SerializeField] private TextMeshProUGUI _textstone;

    [SerializeField] private GameObject _child;
    public GameObject _Archer;
    [SerializeField] private Transform _arhcerpoint;
    private int _archercount=0;
    [SerializeField] private Camera _camera;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        totalif();
        GetComponentInChildren<Canvas>().gameObject.transform.LookAt(_camera.transform);





    }

    

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            i = 1;
        }
    }
    private void OnTriggerStay(Collider other)
    {

        if (other.gameObject.tag == "Player" && (playerController._list.Count - i) != -1)
        {
            
                if (_time <= Time.time && _isneedarcher)
            {
                _time = Time.time + _delay;
                if (playerController._list[playerController._list.Count - i].CompareTag("wood"))
                {

                    if (_isneedwood)
                    {
                        sendmaterial(other.gameObject, i);
                        _woodcount++;
                    }
                    else
                        i++;
                }
                if (playerController._list[playerController._list.Count - i].tag == "gold")
                {
                    if (_isneedgold)
                    {
                        sendmaterial(other.gameObject, i);
                        _goldcount++;
                    }
                    else
                        i++;
                }
                if (playerController._list[playerController._list.Count - i].tag == "stone")
                {
                    if (_isneedstone)
                    {
                        sendmaterial(other.gameObject, i);
                        _stonecount++;
                    }
                    else
                        i++;
                }


            }

        }
    }



    private void sendmaterial(GameObject other, int i)
    {


        Vector3 a1 = playerController._list[playerController._list.Count - i].transform.TransformPoint(Vector3.zero);
        stackmaterial(playerController._list[playerController._list.Count - i]);
        playerController._list[playerController._list.Count - i].transform.parent = null;
        playerController._list[playerController._list.Count - i].transform.TransformPoint(a1);
        playerController._list[playerController._list.Count - i].transform.SetParent(_destroyed.transform);
       
        Vector3 pos = other.transform.localPosition - _destroyed.transform.localPosition;
        //playerController._list[playerController._list.Count - i].transform.position = pos;
        pos.x = 0;
        pos.y = 0;
        pos.z = 0;
        playerController._list[playerController._list.Count - i].gameObject.transform.localRotation = new Quaternion(0, 0.7071068f, 0, 0.7071068f);
        
        //  playerController._list[playerController._list.Count - 1].gameObject.transform.position = Vector3.Slerp(playerController._list[playerController._list.Count - 1].gameObject.transform.position, _destroyed.transform.position,1f);
        playerController._list[playerController._list.Count - i].gameObject.transform.DOLocalMove(pos, 1f);
        
        playerController._list.RemoveAt(playerController._list.Count - i);
        playerController.stacked();
        
    }
    private void stackmaterial(GameObject gameObject)
    {
        if (gameObject.tag == "wood")
        {
            _woodcount += 1;
        }
        if (gameObject.tag == "gold")
        {
            _goldcount += 1;
        }
        if (gameObject.tag == "stone")
        {
            _stonecount += 1;
        }
    }


    private void totalif()
    {
        if (_archercount >= 3)
        {
            _isneedarcher = false;
        }
        else
            _isneedarcher = true;

        //isbuild islemleri
        {
            if (_isbuild)
            {
                _child.active = true;
                _targetgold = 10;
                _targetwood = 5;
                _targetstone = 0;
            }
            else
            {
                _targetwood = 10;
                _targetstone = 10;
                _targetgold = 10;

            }
        }
        //isneed islemleri
        {
            if (_woodcount >= _targetwood)
                _isneedwood = false;
            else
            { _isneedwood = true; }

            if (_goldcount >= _targetgold)
                _isneedgold = false;
            else
            { _isneedgold = true; }

            if (_stonecount >= _targetstone)
                _isneedstone = false;
            else
            { _isneedstone = true; }
        }



        //Text islemleri
        {
            if (_isneedgold)
                _textgold.text = _goldcount + " / " + _targetgold;
            else
                _textgold.text = "";

            if (_isneedstone)
                _textstone.text = _stonecount + " / " + _targetstone;
            else
                _textstone.text = "";

            if (_isneedwood)
                _textwood.text = _woodcount + " / " + _targetwood;
            else

                _textwood.text = "";
        }




        if (!_isneedgold && !_isneedstone && !_isneedwood)
        {
            
            if (_isbuild)
            {
                
                _woodcount = 0;
                _goldcount = 0;
                _stonecount = 0;
                i = 1;

                Instantiate(_Archer,_arhcerpoint.transform.position + new Vector3(-_archercount,0,0),_arhcerpoint.transform.rotation);
                _archercount++;
            }
            else
            {
                
                _woodcount = 0;
                _goldcount = 0;
                _stonecount = 0;
                _isbuild = true;
                i = 1;
            }

        }
    }
}
