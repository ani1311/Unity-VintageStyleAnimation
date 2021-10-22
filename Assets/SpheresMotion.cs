using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpheresMotion : MonoBehaviour
{
    int N = 10;
    List<GameObject> spheres;
    List<GameObject> sphereLights;
    List<float> times;
    List<List<float>> consts;

    // float BoundaryMinX = -10;
    // float BoundaryMaxX = 10;
    // float BoundaryMinY = -3;
    // float BoundaryMaxY = 3;
    // float BoundaryMinZ = -10;
    // float BoundaryMaxZ = 10;

    // Start is called before the first frame update
    void Start()
    {
        spheres = new List<GameObject>();   
        sphereLights = new List<GameObject>();
        times = new List<float>();

        for(int i = 0 ; i < N ; i++) {
            float time = Random.Range(-10.0f, 10.0f);
            // float time = i/5.0f;
            GameObject s = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            s.transform.position = new Vector3(x1(time),y1(time),z1(time));
            s.transform.localScale = new Vector3(0.2f,0.2f,0.2f);

            GameObject lightGameObject = new GameObject();
            Light lightComp = lightGameObject.AddComponent<Light>();
            lightComp.color = Color.blue;
            lightComp.intensity = 0.5f;
            lightGameObject.transform.position = s.transform.position;
            
            spheres.Add(s);
            sphereLights.Add(lightGameObject);
            times.Add(time);

            // for(int i = 0 ; i < Random.Range(0.0f,10.0f) ; i++) {
            //     List<float> c = new List<float>(){Random.Range(0.0f,2.0f),Random.Range(0.0f,8.0f),((int)Random.Range(0.0f,4.0f))%2};
            //     consts[i].AddRange(c);
            // }
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0 ; i < N ; i++) {
            spheres[i].transform.position = new Vector3(x1(times[i]),y1(times[i]),z1(times[i]));
            sphereLights[i].transform.position = spheres[i].transform.position; 
            times[i] = times[i] + 0.01f;
        }
    }

    float x1(float time) {
        return Mathf.Sin(time);
    }
    float y1(float time) {
        return 2.0f*Mathf.Sin(time/1.5f);
    }
    float z1(float time) {
        return 1.0f*Mathf.Sin(time/0.5f) + 0.5f*Mathf.Cos(time/1.5f);
    }

    float x2(float time) {
        return 0;
    }
    float y2(float time) {
        return 0;
    }
    float z2(float time) {
        return 0;
    }
}
