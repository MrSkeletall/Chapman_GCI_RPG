
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]

public class TopDownCC : MonoBehaviour
{

    public float moveSpeed = 20.0f;

    private Rigidbody2D rb;
    private Vector2 input;
    
    
    
    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
        MovePlayer();
    }


    private void FixedUpdate()
    {
       
    }

    void MovePlayer()
    {
        input = GetMoveVector();
        

        rb.velocity = input * moveSpeed;
    }


    public Vector2 GetMoveVector()
    {
         
        return new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }
    
}
