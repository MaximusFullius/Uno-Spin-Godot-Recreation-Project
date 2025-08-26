using Godot;
using Godot.Collections;
using System;


public partial class CardManager : Node2D
{
    public override void _Input(InputEvent @event)
    {
        if (@event is InputEventMouseButton mbe && mbe.ButtonIndex == MouseButton.Left)
        {
            if (mbe.Pressed)
            {
                GD.Print("Clicked"); // raycast check for card
                raycast_check_for_card();
            }
            else
            {
                GD.Print("Released");
            }
        }
    }

    public void raycast_check_for_card()
    {
        var spaceState = GetWorld2D().DirectSpaceState;
        var parameters = new PhysicsPointQueryParameters2D();
        parameters.Position = GetGlobalMousePosition();
        parameters.CollideWithAreas = true;
        parameters.CollisionMask = 1;
        var result = spaceState.IntersectPoint(parameters);

        if (result.Count > 0)
        {
            var collider = result[0]["collider"].As<Node>(); // cast to Node
            if (collider != null)
            {
                var parent = collider.GetParent();
                GD.Print($"Card: {parent}");
            }
        }
    }
    
}
