using UnityEngine;

public class ObjectDestroyer : MonoBehaviour
{
    //this function is called from the animation
    public void DestroyGameObject()
    {
        Destroy(gameObject);
    }
}
