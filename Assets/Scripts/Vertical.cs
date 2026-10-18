using UnityEngine;

public class Vertical : BaseController
{
    public override void OnDown()
    {
        
    }

    public override void OnInteract()
    {

    }

    public override void OnLeft()
    {
        crane.MoveLeft();
        sprite.sprite = sprites[1];
    }

    public override void OnRight()
    {
        crane.MoveRight();
        sprite.sprite = sprites[2];
    }

    public override void OnUp()
    {
        
    }
}
