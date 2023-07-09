using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class SphereRotation : MonoBehaviour
{
    [SerializeField]
    private float rotationSpeed;

    private float radius;

    private Transform center;

    private float angle = 0f;

    private CompositeDisposable disposables = new CompositeDisposable();

    // Start is called before the first frame update
    void Start()
    {
        center = transform.parent;

        radius = Vector3.Distance(this.transform.position, center.position);

        Observable.EveryUpdate().
            Subscribe(x => Rotate())
            .AddTo(disposables);
    }

    private void Rotate()
    {
        angle += rotationSpeed * Time.deltaTime;

        float x = center.position.x + Mathf.Cos(angle) * radius;
        float z = center.position.z + Mathf.Sin(angle) * radius;

        transform.position = new Vector3(x, transform.position.y, z);
    }

    private void OnDestroy()
    {
        disposables.Dispose();
    }

}
