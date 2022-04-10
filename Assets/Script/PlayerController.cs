using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


[RequireComponent(typeof(Rigidbody), typeof(BoxCollider))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigi;
    [SerializeField] private FixedJoystick _joystick;
    [SerializeField] private Animator _anim;
    [SerializeField] private float _moveSpeed;
    public List<GameObject> _list = new List<GameObject>();
    public GameObject PrevObject;
    public GameObject stackedObject;

    void Start()
    {
        stacked();
    }
    void Update()
    {

    }
    private void FixedUpdate()
    {
        _rigi.velocity = new Vector3(_joystick.Horizontal * _moveSpeed, _rigi.velocity.y, _joystick.Vertical * _moveSpeed);

        if (_joystick.Horizontal != 0 || _joystick.Vertical != 0)
        {
            transform.rotation = Quaternion.LookRotation(_rigi.velocity);
            _anim.SetBool("Running", true);
        }
        else
        {
            _anim.SetBool("Running", false);
        }

    }

    public void stacked()
    {
        for (int i = 0; i < _list.Count; i++)
        {
            if (_list[i] == null)
            {
                _list.RemoveAt(i);

            }
            else
            {

            Vector3 pos = PrevObject.transform.localPosition;
                pos.y = i/10f;
                pos.z = 0;
                pos.x = 0;
                _list[i].transform.SetParent(stackedObject.transform);
            _list[i].transform.localRotation = new Quaternion(0, 0.7071068f, 0, 0.7071068f);
            _list[i].gameObject.transform.DOLocalMove(pos, 1f);
            }
        }
    }

    public void Addstack(GameObject other)

    {
        other.transform.SetParent(stackedObject.transform);
        Vector3 pos = PrevObject.transform.localPosition;
        pos.y = _list.Count/10f;
        pos.z = 0;  
        pos.x = 0;
        other.transform.localRotation = new Quaternion(0, 0.7071068f, 0, 0.7071068f);
        other.gameObject.transform.DOLocalMove(pos, 1f);
        _list.Add(other);
    }
    



}
