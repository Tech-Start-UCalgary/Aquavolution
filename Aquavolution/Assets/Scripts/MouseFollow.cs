using UnityEngine;

public class MouseFollow : MonoBehaviour
{
    Vector3 MousePosition;
    public float StartingMoveSpeed;
    public float MinSpeed;
    public float SlowdownFactor;
    Rigidbody2D Rb;
    Vector2 Position = new Vector2(0f, 0f);

    private void Start()
    {
        Rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        // gets in pixels
        MousePosition = Input.mousePosition;
        // convert to world
        MousePosition = Camera.main.ScreenToWorldPoint(MousePosition);

        Position = Vector2.Lerp(transform.position, MousePosition, GetMoveSpeed());
        Rb.MovePosition(Position);
    }

    // Returns move speed, which gets lower as scale increases, to a minimum speed
    private float GetMoveSpeed()
    {
        Vector3 ScaleVector = gameObject.transform.localScale;
        float Scale = ScaleVector.x;

        if (Scale <= 1.5f)
        {
            return StartingMoveSpeed;
        }
        else 
        {
            float Slowdown = Scale * SlowdownFactor;
            if (StartingMoveSpeed - (Slowdown) <= MinSpeed) 
            {
                return(MinSpeed);                
            }
            else 
            {
                return StartingMoveSpeed - Slowdown;
            }
        }
    }
}
