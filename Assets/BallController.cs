using UnityEngine;
using UnityEngine.Events;

public class BallController : MonoBehaviour {
    [SerializeField] private Rigidbody srb;
    [SerializeField] private float ballSpeed = 2f;
    
    public UnityEvent<Vector2> OnMove = new UnityEvent<Vector2>();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        
    }

    public void MoveBall(Vector2 input) {
        Vector3 inputXZPlane = new(input.x, 0, input.y);
        srb.AddForce(inputXZPlane * ballSpeed);
    }

    // Update is called once per frame
    void Update() {
        Vector2 inputVector = Vector2.zero;
        
        if (Input.GetKey(KeyCode.W)) {
            inputVector += Vector2.up;
        }
        
        if (Input.GetKey(KeyCode.S)) {
            inputVector += Vector2.down;
        }
        
        if (Input.GetKey(KeyCode.A)) {
            inputVector += Vector2.left;
        }
        
        if (Input.GetKey(KeyCode.D)) {
            inputVector += Vector2.right;
        }
        
        Vector3 inputXZPlane = new Vector3(inputVector.x, 0, inputVector.y);
        
        srb.AddForce(inputXZPlane);
        
        OnMove?.Invoke(inputVector);
    }
}
