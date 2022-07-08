using UnityEngine;
using UnityEngine.Events;

public class ButtonPhysics : MonoBehaviour
{
    [SerializeField] private float threshold = 0.1f;
    [SerializeField] private float deadzone = 0.025f;

    private bool isPressed;
    private Vector3 startPosition;
    private ConfigurableJoint joint;
    private SoundController soundController;

    public UnityEvent onPressed, onReleased;

    void Start()
    {
        startPosition = transform.localPosition;
        joint = GetComponent<ConfigurableJoint>();
        soundController = GetComponent<SoundController>();
    }

    void Update()
    {
        if (!isPressed && getPress() + threshold >= 1)
             Pressed();
        else if (isPressed && getPress() - threshold <= 0)
             Released();
    }

    private void Pressed()
    {
        isPressed = true;
        soundController.play();
        onPressed.Invoke();
    }

    private void Released()
    {
        isPressed = false;
        onReleased.Invoke();
    }

    private float getPress()
    {
        float distancePercentage = Vector3.Distance(startPosition, transform.localPosition) / joint.linearLimit.limit;
        if (Mathf.Abs(distancePercentage) < deadzone)
            distancePercentage = 0;

        return Mathf.Clamp(distancePercentage, -1f, 1f);
    }
}
