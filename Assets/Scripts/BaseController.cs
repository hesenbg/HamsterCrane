using UnityEngine;

public abstract class BaseController : MonoBehaviour
{
    [SerializeField] public Crane crane;
    protected SpriteRenderer sprite;
    [SerializeField] protected Sprite[] sprites;
    public bool IsInteractable;
    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        sprite.sprite = sprites[0];
    }

    public abstract void OnLeft();

    public abstract void OnRight();

    public abstract void OnUp();

    public abstract void OnDown();

    public abstract void OnInteract();

}