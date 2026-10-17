using Unity.VisualScripting;
using UnityEngine;

public class Box : MonoBehaviour
{
    private void FixedUpdate()
    {
        
    }
    public void Grab(GameObject crane)
    {
        gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;
        gameObject.GetComponent<Rigidbody2D>().freezeRotation = true;
    }
    public void Drop()
    {
        gameObject.GetComponent<Rigidbody2D>().gravityScale = 1;
        gameObject.GetComponent<Rigidbody2D>().freezeRotation = false;
    }
}
