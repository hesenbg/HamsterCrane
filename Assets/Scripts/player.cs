using UnityEngine;

public class player : MonoBehaviour
{
    [Header("Inputs")]
    [SerializeField] KeyCode Up;

    [SerializeField] KeyCode Down;

    [SerializeField] KeyCode Left;

    [SerializeField] KeyCode Right;



    [Header("Components")]
    [SerializeField] Rigidbody2D rb;


    [Header("Variables")]
    [SerializeField] Vector2 Dir;

    public bool CanClimbLadder;

    public bool IsOnLadder;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }


    void Update()
    {

        if (CanClimbLadder)
        {
            if (Input.GetKey(Up))
            {
                Dir += Vector2.up;
            }
            if (Input.GetKey(Down))
            {
                Dir += Vector2.down;
            }
        }

        if (IsOnLadder)
            return;

        if (Input.GetKey(Left))
        {
            Dir += Vector2.left;
        }
        if (Input.GetKey(Right))
        {
            Dir += Vector2.right;
        }

        




    }
}
