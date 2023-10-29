using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierMovement : MonoBehaviour
{
    public float speed = 1f;
    private GameObject _player;

    private void Awake()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
    }
    private void Update()
    {
        Move();
        RemoveClones();
    }

    private void RemoveClones()
    {
        if (transform.position.x < -5)
        {
            Destroy(gameObject);
        }
    }

    private void Move()
    {
        if (_player != null && _player.activeInHierarchy)
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }
    }
}
