using UnityEngine;

public class Triger : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D car)
    {
        Debug.Log("Triger");
        car.GetComponent<Movement>().SetIsMoving(false);
    }
}
