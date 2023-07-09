using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    Animator animator;

    private CompositeDisposable disposables = new CompositeDisposable();


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

        Observable.EveryUpdate()
            .Subscribe(_ => CameraSwitch()).AddTo(disposables);
    }

    // Update is called once per frame
    void CameraSwitch()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (animator.GetCurrentAnimatorStateInfo(0).IsName("SunState"))
            {
                animator.Play("MercuryState");
            }else if (animator.GetCurrentAnimatorStateInfo(0).IsName("MercuryState"))
            {
                animator.Play("VenusState");
            }
            else if (animator.GetCurrentAnimatorStateInfo(0).IsName("VenusState"))
            {
                animator.Play("EarthState");
            }
            else if (animator.GetCurrentAnimatorStateInfo(0).IsName("EarthState"))
            {
                animator.Play("MoonState");
            }
            else if (animator.GetCurrentAnimatorStateInfo(0).IsName("MoonState"))
            {
                animator.Play("MarsState");
            }
            else if (animator.GetCurrentAnimatorStateInfo(0).IsName("MarsState"))
            {
                animator.Play("JupiterState");
            }
            else if (animator.GetCurrentAnimatorStateInfo(0).IsName("JupiterState"))
            {
                animator.Play("SaturnState");
            }
            else if (animator.GetCurrentAnimatorStateInfo(0).IsName("SaturnState"))
            {
                animator.Play("UranusState");
            }
            else if (animator.GetCurrentAnimatorStateInfo(0).IsName("UranusState"))
            {
                animator.Play("NeptuneState");
            }
            else
            {
                animator.Play("SunState");
            }
            
        }
    }
    private void OnDestroy()
    {
        disposables.Dispose();
    }
}
