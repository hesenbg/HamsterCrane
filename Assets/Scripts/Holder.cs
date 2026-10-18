using UnityEngine;

public class Holder : MonoBehaviour
{


    [SerializeField] float Size;

    public bool IsFinished;

    [SerializeField] int MaxHoldCount;

    [SerializeField] int CurrCount = 0;

    private void FixedUpdate()
    {
        Collider2D[] colliders = Physics2D.OverlapBoxAll(transform.position, new Vector2(Size,Size), 0);

        CurrCount = 0;

        foreach(Collider2D collider in colliders)
        {
            if(collider.gameObject.TryGetComponent<Box>(out Box box))
            {
                CurrCount++;
            }
        }

        if(CurrCount == MaxHoldCount)
        {
            IsFinished = true;
        }
        else
        {
            IsFinished = false;
        }
    }
}
