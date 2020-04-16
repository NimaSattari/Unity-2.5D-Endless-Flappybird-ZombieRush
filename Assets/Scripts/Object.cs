using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object : MonoBehaviour
{
    [SerializeField] private float Speed = 5f;
    [SerializeField] private float resetPosition = -43f;
    [SerializeField] private float startPosition = -30.4f;

    protected virtual void Update()
    {
        if (!GameManager.instance.GameOver)
        {
            transform.Translate(Vector3.left * (Time.deltaTime * Speed));
            if (transform.localPosition.x <= resetPosition)
            {
                Vector3 newvector3 = new Vector3(startPosition, transform.position.y, transform.position.z);
                transform.position = newvector3;
            }
        }
    }
}
