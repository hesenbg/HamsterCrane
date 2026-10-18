using Unity.VisualScripting;
using UnityEngine;

public enum BoxColor { Brown,Violet }

public class Box : MonoBehaviour
{

    public BoxColor color;

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
