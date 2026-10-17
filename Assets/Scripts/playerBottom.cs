using UnityEngine;

public class playerBottom : MonoBehaviour
{

    [SerializeField] LayerMask groundMask;

    [SerializeField] player player;

    [SerializeField] float Dist;
     
    private void Start()
    {
        player = GetComponentInParent<player>();
    }

    private void Update()
    {

    }
}
