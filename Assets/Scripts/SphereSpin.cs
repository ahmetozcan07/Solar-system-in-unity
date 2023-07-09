using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class SphereSpin : MonoBehaviour
{
    [SerializeField]
    private float SpinSpeed;

    private float direction;

    private CompositeDisposable disposables = new CompositeDisposable();

    // Start is called before the first frame update
    void Start()
    {
        Observable.EveryUpdate().
            Subscribe(_  => Spin()).
            AddTo(disposables);
    }

    private void Spin()
    {
        if (this.name.Equals("Uranus"))
        {
            
            direction = -1f;

        }else if (this.name.Equals("Venus"))
        {
            direction = -20f;
        }
        else
        {
            direction = 1f;
        }
        transform.Rotate(Vector3.up, SpinSpeed * direction * Time.deltaTime);
    }
    private void OnDestroy()
    {
        disposables.Dispose();
    }
}
