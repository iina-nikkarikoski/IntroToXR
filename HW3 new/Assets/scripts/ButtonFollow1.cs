using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ButtonFollow1 : MonoBehaviour
{
    public Transform visualTarget1;
    public Vector3 localAxis1;
    public float resetSpeed = 5;
    public float followAngleThreshold = 45;

    private bool freeze1 = false;

    private Vector3 initialLocalPos1;

    private Vector3 offset1;
    private Transform pokeAttachTransform1;

    private XRBaseInteractable interactable1;
    private bool isFollowing1 = false;

    private Story story1;
    public bool buttonPressed1 = false;
    public int buttonValue1 = 0;

    void Start()
    {
        initialLocalPos1 = visualTarget1.localPosition;

        interactable1 = GetComponent<XRBaseInteractable>();
        interactable1.hoverEntered.AddListener(Follow);
        interactable1.hoverExited.AddListener(Reset);
        interactable1.selectEntered.AddListener(Freeze);

        interactable1.selectEntered.AddListener(ButtonPressed);
        story1 = GameObject.Find("Interactable1").GetComponent<Story>();
    }

    public void Follow(BaseInteractionEventArgs hover)
    {
        if(hover.interactorObject is XRPokeInteractor)
        {
            XRPokeInteractor interactor = (XRPokeInteractor)hover.interactorObject;

            isFollowing1 = true;

            pokeAttachTransform1 = interactor.attachTransform;
            offset1 = visualTarget1.position - pokeAttachTransform1.position;

            float pokeAngle = Vector3.Angle(offset1, visualTarget1.TransformDirection(localAxis1));

            if(pokeAngle > followAngleThreshold)
            {
                isFollowing1 = false;
                freeze1 = true;
            }
        }
    }

    public void Reset(BaseInteractionEventArgs hover)
    {
        if(hover.interactorObject is XRPokeInteractor)
        {
            isFollowing1 = false;
            freeze1 = false;
        }
    }

    public void Freeze(BaseInteractionEventArgs hover)
    {
        if(hover.interactorObject is XRPokeInteractor)
        {
            freeze1 = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(freeze1)
            return;

        if(isFollowing1)
        {
            Vector3 localTargetPosition = visualTarget1.InverseTransformPoint(pokeAttachTransform1.position + offset1);
            Vector3 constrainedLocalTargetPosition = Vector3.Project(localTargetPosition, localAxis1);

            visualTarget1.position = visualTarget1.TransformPoint(constrainedLocalTargetPosition);
        }
        else
        {
            visualTarget1.localPosition = Vector3.Lerp(visualTarget1.localPosition, initialLocalPos1, Time.deltaTime * resetSpeed);
        }
    }

    public void ButtonPressed(BaseInteractionEventArgs selectEnter)
    {
        if (selectEnter.interactorObject is XRPokeInteractor)
        {
            buttonPressed1 = true;
            buttonValue1 = 1;
            story1.AddButtonIndex(buttonValue1);
        }
    }

    public bool IsButtonPressed()
    {
        return buttonPressed1;
    }
}
