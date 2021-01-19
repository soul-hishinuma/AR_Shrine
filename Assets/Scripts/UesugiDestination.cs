using UnityEngine;

public class UesugiDestination : MonoBehaviour
{
    Location uesugi = new Location(37.91004, 140.10395);

    public GameObject UesugiRotation;

    bool Rotated;

    float SaveRotation;

    float NorthCompass;

    bool saved;

    float direction_float;


    void Start()
    {
        Input.location.Start();

        Input.compass.enabled = true;

        UesugiRotation.SetActive(false);

        Rotated = false;

        saved = false;

    }

    void Update()
    {
        //端末の緯度経度
        LocationInfo locationInfo = Input.location.lastData;
        Location deviceLocation = new Location(locationInfo.latitude, locationInfo.longitude);



        //向き
        Vector3 angle = Vector3.up * -Input.compass.trueHeading;
        double direction = UesugiNaviMath.LatlngDirection(uesugi, deviceLocation);
       direction_float = (float)direction;

        NorthCompass = Input.compass.trueHeading + 90;
        if (NorthCompass > 360)
        {
            NorthCompass -= 360;
        }

        if (saved == false)
        {
          //direction_float = (float)direction;
            Invoke("Saverotation", 1.0f);
        }

        if (Rotated == false)
        {

            if (NorthCompass <= direction_float +20 && NorthCompass >= direction_float - 20)
            {
                UesugiRotation.transform.Rotate(new Vector3(0, direction_float - SaveRotation, 0));


                Rotated = true;

            }

        }

        if (NorthCompass <= direction_float + 20 && NorthCompass >= direction_float - 20)
        {
           

            UesugiRotation.SetActive(true);

        }

        else 
        {
            UesugiRotation.SetActive(false);
        }



    }

    void Saverotation()
    {
        SaveRotation = NorthCompass;
        saved = true;
    }

}