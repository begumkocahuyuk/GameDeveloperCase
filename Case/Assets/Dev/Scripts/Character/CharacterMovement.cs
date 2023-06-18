using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CharacterMovement : MonoBehaviour
{
    [SerializeField] private FloatingJoystick _joystick;
    [SerializeField] private AnimatorController _animatorController;


    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _rotateSpeed;

    private Rigidbody _rigidbody;
    private Vector3 _moveVector;





    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        CharacterMove();
    }

    private void CharacterMove()
    {
        _moveVector = Vector3.zero;
        _moveVector.x = _joystick.Horizontal * _moveSpeed * Time.deltaTime;
        _moveVector.z=_joystick.Vertical*_moveSpeed * Time.deltaTime;

        if(_joystick.Horizontal!=0 || _joystick.Vertical!=0)
        {
            Vector3 addedPos = new Vector3(_moveVector.x * _moveSpeed * Time.deltaTime, 0, _moveVector.z * _moveSpeed * Time.deltaTime);
            transform.position += addedPos;

            Vector3 direction = Vector3.forward * _moveVector.z + Vector3.right * _moveVector.x;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), _rotateSpeed * Time.deltaTime);
            _animatorController.AnimMove();
        }
        else if(_joystick.Horizontal == 0 || _joystick.Vertical == 0)
        {
            _animatorController.AnimIdle();
        } 

    }
}
