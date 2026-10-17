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
    }

    public override void OnRight()
    {
        crane.MoveRight();
        
    }

    public override void OnUp()
    {
        
    }
}
