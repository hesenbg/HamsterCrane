using UnityEngine;

public class Open : BaseController
{
    public override void OnDown()
    {

    }

    public override void OnInteract()
    {
        crane.CloseArm();
        if(sprite.sprite = sprites[1])
            sprite.sprite = sprites[2];
        else
            sprite.sprite = sprites[1];
    }

    public override void OnLeft()
    {

    }

    public override void OnRight()
    {

    }

    public override void OnUp()
    {

    }
}
