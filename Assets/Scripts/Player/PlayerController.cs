using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class PlayerController : MonoBehaviour
{

    public Transform character;
    public Vector3 moveInput;
    public float moveSpeed = 5f;

    public float dashBoost = 2f;
    private float dashTime;
    public float DashTime = 0.25f;
    private bool once;

    private Animator animator;
    private Rigidbody2D rb;

    public GameObject damPopUp;
    public LosePanel losePanel;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // Movement
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");
        transform.position += moveSpeed * Time.deltaTime * moveInput;


        animator.SetFloat("Speed", moveInput.sqrMagnitude);

        //Debug.Log("dashTime: " + dashTime);
        if (Input.GetKeyDown(KeyCode.Space) && dashTime <= 0) //key space Roll character
        {
            animator.SetBool("Roll", true);
            moveSpeed += dashBoost;
            dashTime = DashTime;
            once = true;
        }

        if (dashTime <= 0 && once)
        {
            animator.SetBool("Roll", false);
            moveSpeed -= dashBoost;
            once = false;
        }
        else
        {
            dashTime -= Time.deltaTime;
        }


        // Rotate Face
        if (moveInput.x != 0)
        {
            if (moveInput.x < 0)
            {
                character.transform.localScale = new Vector3(-1, 1, 0);
            }
            else
            {
                character.transform.localScale = new Vector3(1, 1, 0);
            }
        }

    }

    public void TakeDamageEffect(int damage)
    {
        if (damPopUp != null)
        {
            GameObject instance = Instantiate(damPopUp, transform.position
                    + new Vector3(UnityEngine.Random.Range(-0.3f, 0.3f), 0.5f, 0), Quaternion.identity);
            instance.GetComponentInChildren<TextMeshProUGUI>().text = damage.ToString();
            Animator animator = instance.GetComponentInChildren<Animator>();
            animator.Play("red");
        }
        if (GetComponent<Health>().isDead)
        {
            losePanel.Show();
        }
    }

}
