using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour, IDamageable
{
    [SerializeField] Transform playerLocation;
    [SerializeField] int _health = 10;
    [SerializeField] float _bossSpeed = .1f;

    Rigidbody _rb = null;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }
    public void TakeDamage(int damage)
    {
        _health--;
        Debug.Log(_health);
        if(_health <= 0)
        {
            Kill();
        }
    }
    private void Kill()
    {
        gameObject.SetActive(false);
    }

    private void FixedUpdate()
    {
        transform.LookAt(playerLocation);
        Vector3 moveDirection = transform.forward * _bossSpeed;
        _rb.AddForce(moveDirection);
    }

}
