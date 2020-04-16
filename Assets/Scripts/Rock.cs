using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : Object
{
    [SerializeField] Vector3 topPosition;
    [SerializeField] Vector3 bottomPosition;
    [SerializeField] float waitTime;
    [SerializeField] float UDSpeed;

    void Start()
    {
        StartCoroutine(Move(bottomPosition));
    }

    protected override void Update()
    {
        if (GameManager.instance.PlayerActive)
        {
            base.Update();
        }
    }

    IEnumerator Move(Vector3 target)
    {
        while(Mathf.Abs((target - transform.localPosition).y) > 0.5f)
        {
            Vector3 direction = target.y == topPosition.y ? Vector3.up : Vector3.down;
            transform.localPosition += direction * Time.deltaTime * UDSpeed;
            yield return null;
        }
        yield return new WaitForSeconds(waitTime);
        Vector3 newtarget = target.y == topPosition.y ? bottomPosition : topPosition;
        StartCoroutine(Move(newtarget));
    }
}
