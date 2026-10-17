using UnityEngine;

public enum movementState { idle, ladder, crane };

public class player : MonoBehaviour
{
    [Header("Inputs")]
    [SerializeField] KeyCode Up;

    [SerializeField] KeyCode Down;

    [SerializeField] KeyCode Left;

    [SerializeField] KeyCode Right;

    [SerializeField] KeyCode Interact;


    [Header("Components")]
    [SerializeField] Rigidbody2D rb;

    BaseController Closest = null;

    [Header("Variables")] 
    [SerializeField] Vector2 Dir;

    [SerializeField] float LadderSpeed;

    [SerializeField] float HorizontalSpeed;

    [SerializeField] LayerMask LadderLayer;

    [SerializeField] LayerMask GroundLayer;

<<<<<<< Updated upstream
    [SerializeField] LayerMask Controller;

    [SerializeField] float ControllerAccessDistance;

    float baseGravity;
=======
    float baseGravity = 10;
>>>>>>> Stashed changes

    public bool OnGround = false;

    public movementState state;

    public bool CanClimbLadder = false;

    public bool IsOnLadder = false;

    GameObject closestLadder;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (1 << collision.gameObject.layer == LadderLayer.value)
        {
            closestLadder = collision.gameObject;
            CanClimbLadder = true;
        }

        if (1 << collision.gameObject.layer == GroundLayer.value)
            OnGround = true;
    }

    

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (1 << collision.gameObject.layer == LadderLayer.value)
            CanClimbLadder = true;

        if (1 << collision.gameObject.layer == GroundLayer.value)
        {
            if(!CanClimbLadder)
                transform.position = new Vector3(transform.position.x, collision.transform.position.y+1, transform.position.z);
            OnGround = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (1 << collision.gameObject.layer == LadderLayer.value)
            CanClimbLadder = false;

        if (1 << collision.gameObject.layer == GroundLayer.value)
            OnGround = false;
    }

    private void Idle()
    {
        if (Input.GetKey(Left) )
        {
            Dir += Vector2.left * HorizontalSpeed;

        }
        if (Input.GetKey(Right))
        {
            Dir += Vector2.right * HorizontalSpeed;
        }

        if ((Input.GetKey(Up) || Input.GetKey(Down)) && CanClimbLadder)
        {
            Vector2 pos = transform.position;

            pos.x = closestLadder.transform.position.x;

            transform.position = pos;
            state = movementState.ladder;
        }
    }

    private void Ladder()
    {
        if (Input.GetKey(Up) && (CanClimbLadder || OnGround))
        {
            Dir += Vector2.up*LadderSpeed;
        }
        if (Input.GetKey(Down) && (CanClimbLadder || OnGround))
        {
            Dir += Vector2.down*LadderSpeed;
        }

        if (!CanClimbLadder || OnGround )
        {
            state = movementState.idle;
        }
    }

    private void Crane()
    {

    }

    float mindistance =  float.MaxValue;


    void Update()
    {
        Dir = Vector2.zero;

        rb.gravityScale = CanClimbLadder ? 0 : baseGravity;

        switch (state)
        {
            case movementState.idle:
                Idle();
                break;
            case movementState.ladder:
                Ladder();
                break;
            case movementState.crane:
                Crane();
                break;
        }


        if (Input.GetKeyDown(Interact))
        {
            Collider2D[] all = Physics2D.OverlapCircleAll(transform.position, ControllerAccessDistance, Controller);


            mindistance = float.MaxValue;

            foreach(Collider2D col in all)
            {

                Debug.Log(col);

                float distance =Vector2.Distance(col.transform.position, transform.position);

                if (distance < mindistance && col.gameObject.TryGetComponent<BaseController>(out BaseController cont))
                {
                    mindistance = distance;

                    Closest = cont;
                }
            }

            if(Closest!= null)
            {
                if (Closest.IsInteractable)
                {
                    if(state != movementState.crane)
                    {
                        state = movementState.crane;
                    }
                    else
                    {
                        state = movementState.idle;
                    }
                }
            }

        }
        rb.linearVelocity = Dir;
    }
}