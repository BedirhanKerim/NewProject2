using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackMember : MonoBehaviour
{ public float speed = 5.0f;

    private float _direction;
    // Start is called before the first frame update
    void Start()
    {
        _direction = transform.position.x > 0 ? 1 : -1;
        StackController.Instance.StackStopAndCut += Cut;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        transform.Translate(Vector3.left*_direction * speed * Time.deltaTime);

    }

    private void Cut(Transform oldStack)
    {
        if (CubeCut.Cut(transform,  oldStack))
        {
                    StackController.Instance.StackStopAndCut -= Cut;
                    Destroy(this.gameObject);
        }



    }
}
