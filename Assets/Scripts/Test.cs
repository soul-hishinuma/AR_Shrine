using UnityEngine;

public class Test : MonoBehaviour
{
    Location kanahebi = new Location(38.11988, 140.83822);
    Location myu = new Location(38.35002, 140.84068);

    void Start()
    {

        Input.location.Start();

        LocationInfo locationInfo = Input.location.lastData;

        Debug.Log("宮城大学とカナヘビ水神社の距離は" + NaviMath.LatlngDistance(myu, kanahebi) + "kmだよ");
        Debug.Log("宮城大学からカナヘビ水神社の方位角は" + NaviMath.LatlngDirection(myu, kanahebi) + "だよ");
    }

    void Update()
    {
        //端末の緯度経度
        
        //Location deviceLocation = new Location(locationInfo.latitude, locationInfo.longitude);
    }
    }