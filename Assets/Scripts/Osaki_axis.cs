using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Osaki_axis : MonoBehaviour
{
    public double latitude = 38.272610;   // 大崎の緯度
    public double longitude = 140.844950;  // 大崎の経度
    const double lat2km = 111319.491;


    public Vector3 ConvertGPS2km(LocationInfo location)
    {
        double dz = (latitude - location.latitude) * lat2km;   // -zが南方向
        double dx = -(longitude - location.longitude) * lat2km; // +xが東方向
        return new Vector3((float)dx, 0, (float)dz);
    }

    public float GetAxis(LocationInfo location)
    {
        //Vector3 my_location = new Vector3((float)location.latitude, 0, (float)location.longitude);
        //double dz = (latitude - location.latitude) * lat2km;   // -zが南方向
        //double dx = -(longitude - location.longitude) * lat2km; // +xが東方向
        //Vector3 osaki_location = new Vector3((float)dx, 0, (float)dz);
        //public static float angle = Angle(my_location, osaki_location);
        //return angle;
        float rad = Mathf.Atan2((float)latitude - (float)location.latitude, (float)longitude - (float)location.longitude);
        float deg = rad * Mathf.Rad2Deg;
        return deg;
    }

    void Start()
    {

        Input.location.Start();

       Invoke("UpdateGPS", 1.0f);
    }

    void Update()
    {
        

    }

    public void UpdateGPS()
    {
        if (Input.location.isEnabledByUser)
        {
            if (Input.location.status == LocationServiceStatus.Running)
            {
                LocationInfo location = Input.location.lastData;

                transform.position = ConvertGPS2km(location);

                Debug.Log(GetAxis(location));
            }
        }
    }

    
}
