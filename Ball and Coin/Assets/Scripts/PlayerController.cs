using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] float speed = 10f;
    float _speed;

    Rigidbody rb;

    Vector3 velocity;
    [HideInInspector]
    public GameController controller;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        controller = FindObjectOfType<GameController>();
    }
    // Start is called before the first frame update
    void Start()
    {
        _speed = speed;
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = velocity*_speed;
        if(transform.position.y < -0.2f)
        {
            controller.EndGame();
        }
    }
    public void SetSpeed(float value)
    {
        _speed *= value; //Mathf.Lerp(_speed*value, speed/2, speed*2);
    }
    private void FixedUpdate()
    {
        CheckInput();
    }

    void CheckInput()
    {
        velocity = Vector2.zero;

        velocity.x = Input.GetKey(KeyCode.LeftArrow) ? -1 : Input.GetKey(KeyCode.RightArrow) ? 1 : 0;
        velocity.z = Input.GetKey(KeyCode.UpArrow) ? 1 : Input.GetKey(KeyCode.DownArrow) ? -1 : 0;
    }

}
