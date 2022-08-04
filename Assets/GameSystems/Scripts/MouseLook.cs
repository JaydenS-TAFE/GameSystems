using UnityEngine;
using System.Collections;

[AddComponentMenu("Game Systems/Player/MouseLook")]
public class MouseLook : MonoBehaviour
{
    #region RotationalAxis
    //Create a public enum called RotationalAxis
    public enum RotationalAxis
    {
        MouseX,
        MouseY,
    }
    #endregion
    #region Variables
    [Header("Rotation")]
    //create a public link to the rotational axis called axis and set a defualt axis
    public RotationalAxis axis = RotationalAxis.MouseX;
    [Header("Sensitivity")]
    //public floats for our x and y sensitivity
    public Vector2 sensitivity = new Vector2(2f, 2f);
    //[Range(0f, 100f)]
    //[Header("Y Rotation Clamp")]
    //max and min Y rotation
    public float minY = -90f, maxY = 90f;
    //we will have to invert our mouse position later to calculate our mouse look correctly
    public bool isInverted;
    //float for rotation Y
    private float _yRotation;
    #endregion
    #region Start
    //Lock Cursor to middle of screen
    //Hide Cursor from view
    //if our game object has a rigidbody attached to it
    //set the rigidbodys freezRotaion to true
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        if (TryGetComponent(out Rigidbody rigidbody))
        {
            rigidbody.freezeRotation = true;
        }
        if (TryGetComponent(out Camera camera))
        {
            axis = RotationalAxis.MouseY;
        }
    }
    #endregion
    #region Update
    #region Mouse X
    //if we are rotating on the X
    //transform the rotation on our game objects Y by our Mouse input Mouse X times X sensitivity
    //x                y                          z
    #endregion
    #region Mouse Y
    //else we are only rotation on the Y
    //our rotation Y is pulse equals  our mouse input for Mouse Y times Y sensitivity
    //the rotation Y is clamped using Mathf and we are clamping the y rotation to the Y min and Y max
    //transform our local position to the nex vector3 rotaion - y rotaion on the x axis and local euler angle Y on the y axis
    #endregion

    private void Update()
    {
        if (axis == RotationalAxis.MouseX)
        {
            transform.Rotate(0f, Input.GetAxisRaw("Mouse X") * sensitivity.x, 0f);
        }
        else
        {
            _yRotation = Mathf.Clamp(_yRotation + (Input.GetAxisRaw("Mouse Y") * (isInverted ? -sensitivity.y : sensitivity.y)), minY, maxY);
            transform.localRotation = Quaternion.Euler(_yRotation, 0f, 0f);
        }
    }
    #endregion
}













