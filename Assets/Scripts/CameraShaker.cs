using UnityEngine;

public class CameraShaker : MonoBehaviour
{
    [SerializeField] private float maxShakeAmount = 1.5f; //how far the camera can move from its start position
    [SerializeField] private float lerpSpeed = 5.0f; //higher = faster, snappier shake

    private Vector3 startPosition;
    private Vector3 targetPosition;
    private Transform mainCamera;

    private void Start()
    {
        //Main Camera is the child of this object
        //you could also do mainCamera = Camera.main
        //but in this case that would be less efficient
        mainCamera = transform.GetChild(0);

        startPosition = mainCamera.transform.localPosition;
        targetPosition = startPosition;
    }

    private void Update()
    {
        //Lerp moves a bit closer to the target each frame, which gives a smooth motion
        mainCamera.localPosition = Vector3.Lerp(mainCamera.localPosition, targetPosition, lerpSpeed * Time.deltaTime);

        //Once the shake target is (almost) reached, move back to the start position
        if (targetPosition != startPosition && (mainCamera.localPosition - targetPosition).sqrMagnitude < 0.0001f)
        {
            targetPosition = startPosition;
        }
    }

    //call this whenever the camera should shake
    public void ShakeCamera()
    {
        //pick a random point inside a circle and use it as an offset from the start position
        Vector2 offset = Random.insideUnitCircle * maxShakeAmount;
        targetPosition = startPosition + new Vector3(offset.x, offset.y, 0f);
    }
}
