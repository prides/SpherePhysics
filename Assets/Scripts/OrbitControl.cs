using UnityEngine;

public class OrbitControl : MonoBehaviour
{
    private BaseInput mInput;
    private Transform mTransform;
    private PolarSystemTransform mPolarSystemTransform;

    [SerializeField]
    private ControlType currentType;

    private void Start()
    {
        mPolarSystemTransform = GetComponent<PolarSystemTransform>();

        mTransform = transform;

        switch (currentType)
        {
            default:
            case ControlType.Mouse:
                mInput = new MouseInput();
                break;
            case ControlType.Touch:
                mInput = new MobileTouchInput();
                break;
        }

        mInput.OnMoveEvent += OnMove;
        mInput.OnRotateEvent += OnRotate;
    }

    private void LateUpdate()
    {
        mInput.InputEvent();
        mPolarSystemTransform.LookAt();
    }

    private void OnDestroy()
    {
        mInput.OnMoveEvent -= OnMove;
        mInput.OnRotateEvent -= OnRotate;
    }

    private void OnMove(Vector3 delta)
    {
        mPolarSystemTransform.Move(delta);
    }

    private void OnRotate(Vector3 delta)
    {
        mPolarSystemTransform.Rotate(delta);
    }

    public enum ControlType
    {
        Mouse,
        Touch
    }
}
