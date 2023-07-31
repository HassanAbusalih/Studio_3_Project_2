using UnityEngine;

/// <summary>
/// This is an abstract class that every object that is reset when the player dies at a checkpoint uses. The only reason it is an abstract class is because Unity 
/// does not serialize interfaces.
/// </summary>

public abstract class Resetable : MonoBehaviour
{
    /// <summary>
    /// The method that is called to reset the object back to its original state.
    /// </summary>
    public abstract void ResetObject();
}
