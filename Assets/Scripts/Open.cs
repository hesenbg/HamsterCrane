using UnityEngine;

public class Close : BaseController
{
    
    public override void OnDown()
    {

    }

    public override void OnInteract()
    {
        crane.OpenArm();
        if(sprite.sprite = sprites[2])
            sprite.sprite = sprites[1];
        else
            sprite.sprite = sprites[2];
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
