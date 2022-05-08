
using System;
using UnityEngine;
using UnityEngine.Serialization;

public class CameraFollowing2D : MonoBehaviour
{
    [Header("Parameters")]
    [SerializeField] private Transform playerTransform;
    [SerializeField] private string playerTag;
    [SerializeField] private float movingSpeed;

    private void Awake()
    {
        if (this.playerTransform == null)
        {
            if (this.playerTag == "")
            {
                this.playerTag = "Player";
            }
            this.playerTransform = GameObject.FindGameObjectWithTag(this.playerTag).transform;
        }

        this.transform.position = new Vector3()
        {
            x = this.playerTransform.position.x,
            y = this.playerTransform.position.y,
            z = this.playerTransform.position.z-0.5f,
        };
    }

    private void Update()
    {
        if (this.playerTransform)
        {
            var target = new Vector3()
            {
                x = this.playerTransform.position.x,
                y = this.playerTransform.position.y,
                z = this.playerTransform.position.z -0.5f,
            };
            var pos = Vector3.Lerp(this.transform.position, target, this.movingSpeed * Time.deltaTime);

            this.transform.position = pos;
        }
        
    }
}
