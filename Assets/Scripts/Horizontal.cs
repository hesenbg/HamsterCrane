using UnityEngine;

public class Horizontal : BaseController
{
    public override void OnDown()
    {
        crane.MoveDown();
        sprite.sprite = sprites[2];
    }

    public override void OnInteract()
    {


    }

    public override void OnLeft()
    {

    }

    public override void OnRight()
    {

    }

    public override void OnUp()
    {
        crane.MoveUp();
        sprite.sprite = sprites[1];
    }
}
