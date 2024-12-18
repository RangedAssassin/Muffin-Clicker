using UnityEngine;

public static class MyToolbox
{
    public static Vector2 GetRandomVector2(float minX,float maxX,float minY,float maxY)
    {      
        Vector2 value = new Vector2();
        value.x = Random.Range(minX, maxX);
        value.y = Random.Range(minY, maxY);
        return value;
    }
}
