using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody rb;
    public float moveSpeed = 5f;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }



    void Update()
    {
        float v = Input.GetAxis("Vertical");
        float h = Input.GetAxis("Horizontal");

        rb.linearVelocity = new Vector3(h, v, 0f) * moveSpeed;
    }
}
