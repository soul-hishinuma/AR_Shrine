using UnityEngine;

public class TakekomaDestination : MonoBehaviour
{
    Location takekoma = new Location(38.10544, 140.86165);

    public GameObject TakekomaRotation;

    bool Rotated;

    float SaveRotation;

    float NorthCompass;

    bool saved;

    float direction_float;




    void Start()
    {
        Input.location.Start();

        Input.compass.enabled = true;

        TakekomaRotation.SetActive(false);

        Rotated = false;

        saved = false;

        

    }

    void Update()
    {
        //端末の緯度経度

        LocationInfo locationInfo = Input.location.lastData;
        Location deviceLocation = new Location(locationInfo.latitude, locationInfo.longitude);


        //向き
     
        double direction = TakekomaNaviMath.LatlngDirection(takekoma, deviceLocation);
        direction_float = (float)direction;

        NorthCompass = Input.compass.trueHeading + 90;
        if (NorthCompass > 360)
        {
            NorthCompass -= 360;
        }

        if (saved == false)
        {
            
            Invoke("Saverotation", 1.0f);
        }

        if (Rotated == false)
        {

            if (NorthCompass <= direction_float + 20& NorthCompass >= direction_float -20)
            {
                TakekomaRotation.transform.Rotate(new Vector3(0, direction_float - SaveRotation, 0));


                Rotated = true;

            }

        }

        if (NorthCompass <= direction_float +20 && NorthCompass >= direction_float -20)
        {


            TakekomaRotation.SetActive(true);

        }

        else
        {
           TakekomaRotation.SetActive(false);
        }




    }

    void Saverotation()
    {
        SaveRotation = NorthCompass;
        saved = true;
    }

}