using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;


public class PlayerScript : MonoBehaviour
{
    [SerializeField] private float _velocity = 1.5f;
    [SerializeField] private ParticleSystem _death;

    public bool isAlive = true;
    public AudioClip wing, hit, point;

    ScoreScript _scoreScript;
    private bool _isMoving =  false;
    private AudioSource _audioSource;
    private Rigidbody2D _playerRB;

    void Start()
    {
        _death.Stop();
        _playerRB = GetComponent<Rigidbody2D>();
        GameObject score = GameObject.Find("Counter");

        _scoreScript = score.GetComponent<ScoreScript>();
        _audioSource = GetComponent<AudioSource>(); 
        
        isAlive = true;
    }

    void Update()
    {
        for (int i = 0; i<Input.touchCount;i++)
        {
            if (Input.GetTouch(i).phase == TouchPhase.Began && isAlive)
            {
                _audioSource.PlayOneShot(wing);
                transform.eulerAngles = new Vector3(0, 0, 30);
                _playerRB.velocity = Vector2.up * _velocity;
            }
        }
        if (transform.eulerAngles.z>-30)
        {
            transform.eulerAngles += new Vector3(0, 0, -5 * Time.deltaTime *10);
        }
        
    }

    private void OnCollisionEnter2D(Collision2D target)
    {
        if (target.gameObject.tag=="Box")
        {

            _death.Play();
            _audioSource.PlayOneShot(hit);
            isAlive = false;
            Destroy(this.gameObject,1f);
        }
    }

    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.gameObject.CompareTag("Count"))
        {
            _audioSource.PlayOneShot(point);
            _scoreScript.score++;
            _scoreScript.ScoreDisplay();
            Debug.Log(_scoreScript.score);
        }
    }
}
