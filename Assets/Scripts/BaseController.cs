using UnityEngine;

public abstract class BaseController : MonoBehaviour
{
    [SerializeField] public Crane crane;

    public bool IsInteractable;


    public abstract void OnLeft();

    public abstract void OnRight();

    public abstract void OnUp();

    public abstract void OnDown();

    public abstract bool OnInteract();

}