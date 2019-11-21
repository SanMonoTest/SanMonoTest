using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCtrl : MonoBehaviour
{
    public float CharacterSpeed = 2f;
    public float lockAnimaSpeed = 1f; //速度N以下鎖面向
    protected float _horizontalMove = 0f;
    protected float _verticalMove = 0f;
    protected float _preSpeed = 0f;
    //public float angle = 0f;
    protected Vector2 _movement;
    protected Animator _animator;
    public Rigidbody2D _rigidBody2D;
    protected virtual void Start() {
        _animator = GetComponent<Animator>();
        _rigidBody2D = GetComponent<Rigidbody2D>();
    }
    void Update() {
        _preSpeed = _rigidBody2D.velocity.magnitude;
        SetMovement(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    }
    protected virtual void FixedUpdate() {
        Movement();
        UpdateAnimator();
    }
    protected virtual void SetMovement(float movementX, float movementY) {
        _horizontalMove = movementX;
        _verticalMove = movementY;
    }

    protected virtual bool SpeedDown() {
        if (_preSpeed - _rigidBody2D.velocity.magnitude >= 0) {
            return true; //減速過程、停止、極速
        } else {
            return false; //加速過程
        }
    }
    protected virtual void Movement() {
        _movement = new Vector2(_horizontalMove, _verticalMove);
        _movement *= CharacterSpeed;
        _rigidBody2D.velocity = _movement;
    }
    protected virtual void UpdateAnimator() {
        if (_animator != null) {
            _animator.SetFloat("Speed", _rigidBody2D.velocity.magnitude);
            if (!SpeedDown() || _rigidBody2D.velocity.magnitude > lockAnimaSpeed) {
                    _animator.SetFloat("inputH", _horizontalMove);
                    _animator.SetFloat("inputV", _verticalMove);
            }
        }
    }
}
