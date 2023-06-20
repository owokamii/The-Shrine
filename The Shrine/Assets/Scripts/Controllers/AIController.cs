using UnityEngine;

[CreateAssetMenu(fileName = "AIController", menuName = "InputController/AIController")]
public class AIController : InputController
{
    public override bool RetrieveJumpInput(GameObject gameObject)
    {
        return true;
    }

    public override float RetrieveMoveInput(GameObject gameObject)
    {
        return 1f;
    }

    public override bool RetrieveJumpHoldInput(GameObject gameObject)
    {
        return false;
    }
    public override bool RetrieveCrouchInput(GameObject gameObject)
    {
        return false;
    }
}
