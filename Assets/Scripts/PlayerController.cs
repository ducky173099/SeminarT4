using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public Transform character;
    private float xInput;
    private float yInput;
    private float moveSpeed = 5f;

    [SerializeField] private Rigidbody2D rb;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        xInput = Input.GetAxis("Horizontal");
        yInput = Input.GetAxis("Vertical");
    }


    private void FixedUpdate()
    {
        character.Translate(xInput * moveSpeed, yInput * moveSpeed, 0);
    }
}
