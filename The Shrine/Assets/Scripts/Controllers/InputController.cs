using UnityEngine;

public abstract class InputController : ScriptableObject
{
    public abstract float RetrieveMoveInput(GameObject gameObject);
    public abstract bool RetrieveJumpInput(GameObject gameObject);
    public abstract bool RetrieveJumpHoldInput(GameObject gameObject);
    public abstract bool RetrieveCrouchInput(GameObject gameObject);
}
