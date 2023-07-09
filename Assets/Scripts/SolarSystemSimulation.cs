using UnityEngine;
using UniRx;
using System.Collections;

public class SolarSystemSimulation : MonoBehaviour
{
    private Transform sun;
    private Transform[] planets;

    [SerializeField]
    private float[] planetSpeeds;

    [SerializeField]
    private float[] planetRotationSpeeds;

    private CompositeDisposable disposables = new CompositeDisposable();

    private void Start()
    {
        sun = GetComponent<Transform>();
        planets = GetComponentsInChildren<Transform>();

        FloatReactiveProperty sunRotationSpeed = new FloatReactiveProperty(2f);


        Observable.EveryUpdate()
            .Subscribe(_ => sun.Rotate(Vector3.up, sunRotationSpeed.Value * Time.deltaTime))
            .AddTo(disposables);


        
        
        Debug.Log(planetSpeeds.Length+"   "+planets.Length);


        for (int i = 0; i < planets.Length; i++)
        {
            
            Debug.Log(planets[i].gameObject.ToString());


            int index = i;

            Debug.Log(planetRotationSpeeds[index]+ "asdasdasdasd");

            Observable.EveryUpdate()
                .Subscribe(_ => planets[index].Rotate(new Vector3(0, planetRotationSpeeds[index], 0) * Time.deltaTime))
                .AddTo(disposables);
        }
    }

    private void OnDestroy()
    {
        disposables.Dispose();
    }
}