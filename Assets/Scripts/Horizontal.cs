using UnityEngine;

public class Horizontal : BaseController
{
    public override void OnDown()
    {
        crane.MoveDown();

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

    }
}
