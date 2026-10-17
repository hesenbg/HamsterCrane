using UnityEngine;

public class Close : BaseController
{
    
    public override void OnDown()
    {

    }

    public override void OnInteract()
    {
        crane.OpenArm();
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
