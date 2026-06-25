using NUnit.Framework.Constraints;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class WorldRotator : MonoBehaviour
{
    [Header("-------------- Required Objects")]
    [SerializeField] private InputActionReference deltaAction;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Move(InputAction.CallbackContext obj)
    {
        float sensitivity = 1.0f;
        var rb = gameObject.GetComponent<Rigidbody>();
        var delta = obj.ReadValue<Vector2>() * sensitivity * Time.deltaTime;
        delta.x = Mathf.Clamp(delta.x, -1, 1);
        delta.y = Mathf.Clamp(delta.y, -1, 1);
        rb.angularVelocity += new Vector3(delta.y, delta.x, 0) * delta.magnitude;
        // rb.angularVelocity += new Vector3(delta.x, delta.y, 0);
    }

    private void OnEnable()
    {
        deltaAction.action.performed += Move;
    }

    private void OnDisable()
    {
        deltaAction.action.performed -= Move;
    }
}
