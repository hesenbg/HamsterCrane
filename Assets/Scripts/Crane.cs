using NUnit.Framework;
using UnityEngine;
using UnityEngine.InputSystem;

public class Crane : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    private GameObject grabbedBox = null;
    private void Start()
    {
        
    }
    private void Update()
    {
        rb.linearVelocity = Vector2.zero;
        if (Input.GetKey(KeyCode.W))
        {
            MoveUp();
        }
        if (Input.GetKey(KeyCode.S))
        {
            MoveDown();
        }
        if (Input.GetKey(KeyCode.A))
        {
            MoveLeft();
        }
        if (Input.GetKey(KeyCode.D))
        {
            MoveRight();
        }
        if (Input.GetKeyDown(KeyCode.Space) && grabbedBox is null)
        {
            CloseArm();
        }
        else if (Input.GetKeyDown(KeyCode.Space) && grabbedBox is not null)
        {
            OpenArm();
        }
    }
    private void FixedUpdate()
    {
        if (grabbedBox)
        {
            grabbedBox.transform.position = (Vector2)transform.position + new Vector2(0, -0.25f);;
        }
    }
    private void MoveUp()
    {
        rb.linearVelocity += Vector2.up * 2;
    }
    private void MoveDown()
    {
        rb.linearVelocity += Vector2.down * 2;
    }
    private void MoveLeft()
    {
        rb.linearVelocity += Vector2.left * 2;
    }
    private void MoveRight()
    {
        rb.linearVelocity += Vector2.right * 2;
    }
    private void CloseArm()
    {
        Vector2 pivotpoint = (Vector2)transform.position + new Vector2(0, -0.25f);
        var colliders = Physics2D.OverlapCircleAll(pivotpoint, 0.25f, 256);
        Collider2D closestCollider = null;
        float closestDistance = 1;
        foreach(var collider in colliders)
        {
            if (((Vector2)collider.gameObject.transform.position - pivotpoint).magnitude < closestDistance)
            {
                closestDistance = ((Vector2)collider.gameObject.transform.position - pivotpoint).magnitude;
                closestCollider = collider;
            }
        }
        if (closestCollider is not null)
        {
            closestCollider.gameObject.GetComponent<Box>().Grab(gameObject);
            grabbedBox = closestCollider.gameObject;
        }
    }
    private void OpenArm()
    {
        grabbedBox.GetComponent<Box>().Drop();
        grabbedBox = null;
    }
}
