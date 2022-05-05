using UnityEngine;

public class Triger : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D car)
    {
        car.GetComponent<Movement>().SetIsMoving(false);
    }
}
