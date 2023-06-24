using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class TextureGenerator{
   
    public static Texture2D TextureFromColourMap(Color[] colourMap, int width, int height)
    {
        Texture2D texture = new Texture2D(width, height);
        texture.filterMode = FilterMode.Point;
        texture.wrapMode = TextureWrapMode.Clamp;
        texture.SetPixels(colourMap);
        texture.Apply();
        return texture;
    }

    public static Texture2D TextureFromHeightMap(float[,] heightMap) 
    {
        int widht = heightMap.GetLength(0);
        int height = heightMap.GetLength(1);


        Color[] colourMap = new Color[widht * height];

        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < widht; x++)
            {

                colourMap[x * widht + y] = Color.Lerp(Color.black, Color.white, heightMap[x, y]);
            }
        }
        return TextureFromColourMap(colourMap, widht, height);
    }

}
