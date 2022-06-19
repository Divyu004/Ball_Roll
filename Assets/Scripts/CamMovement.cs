using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMovement : MonoBehaviour
{
    [SerializeField] private GameObject _ball;
    [SerializeField] private Vector3 _offset;

    private void Start()
    {
        _offset = transform.position - _ball.transform.position;
    }
    private void LateUpdate()
    {
        transform.position = _ball.transform.position+_offset;

    }
}
