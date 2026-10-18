using System;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.InputSystem;

public class Crane : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    private GameObject grabbedBox = null;
    private Vector2 velocityVector = Vector2.zero;
    [SerializeField] private Sprite[] sprites;
    private SpriteRenderer sprite;

    private void Start()
    {
       sprite = GetComponentInChildren<SpriteRenderer>();
    }
    private void Update()
    {
        rb.linearVelocity = velocityVector;
        velocityVector = Vector2.zero;
    }
    private void FixedUpdate()
    {
        if (grabbedBox)
        {
            grabbedBox.transform.position = (Vector2)transform.position + new Vector2(0, -0.65f);;
        }
    }
    public void MoveUp()
    {
        velocityVector += Vector2.up * 2;
    }
    public void MoveDown()
    {
        velocityVector += Vector2.down * 2;
    }
    public void MoveLeft()
    {
        velocityVector += Vector2.left * 2;
    }
    public void MoveRight()
    {
        velocityVector += Vector2.right * 2;
    }
    public void ToggleArm()
    {
        if(grabbedBox is null)
        {
            CloseArm();
        }
        else OpenArm();
    }
    public void CloseArm()
    {
        Vector2 pivotpoint = (Vector2)transform.position + new Vector2(0, -0.65f);
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
            sprite.sprite = sprites[1];
        }
    }
    public void OpenArm()
    {
        if(grabbedBox is null) return;
        
        sprite.sprite = sprites[0];
        grabbedBox.GetComponent<Box>().Drop();
        grabbedBox = null;
    }
}
