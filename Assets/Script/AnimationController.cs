using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    private GameObject _player;
    [SerializeField] private Animator _building, _cloud, _bushes, _ground;

    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");

    }

    private void Update()
    {
        if (_player ==null || !_player.activeInHierarchy)
        {
            _building.speed = 0;
            _cloud.speed = 0;
            _bushes.speed = 0;
            _ground.speed = 0;
        }
        
    }

}
