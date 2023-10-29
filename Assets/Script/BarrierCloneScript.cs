using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierCloneScript : MonoBehaviour
{
    [SerializeField] private GameObject _barrierPrefab;
    [SerializeField] private GameObject _player;
    [SerializeField] private Transform _location;

    int i = 0;

    PlayerScript _playerScript;

    void Start()
    {
        _playerScript = _player.GetComponent<PlayerScript>();
        Instantiate(_barrierPrefab, _location.position, Quaternion.identity);
        StartCoroutine(CloneBarrier());
        
    }

    IEnumerator CloneBarrier()
    {
        while (_playerScript.isAlive==true)
        {
            _location.position = new Vector3(_location.position.x, Random.Range(-1.6f,1.6f) , _location.position.z);
            yield return new WaitForSeconds(5f);
            Instantiate(_barrierPrefab, _location.position , Quaternion.identity);
            i++;
        }
    }

}
