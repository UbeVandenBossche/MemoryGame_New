using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Memory.Utilities;
using System;
using UnityEngine.Networking;
using System.Linq;
using Newtonsoft.Json;

public class ImageRepository : Singleton<ImageRepository>
{
    string urlMemoryImages = "http://www.memorygame.edu/MemoryService/api/Memory";

    

    
    public void GetProcessTexture(int imgID, Action<Texture2D> processTexture)
    {
        StartCoroutine(GetTextures(imgID, processTexture));
    }
    private IEnumerator GetTextures(int imgID, Action<Texture2D> processTexture)
    {
        UnityWebRequest uwrt = UnityWebRequestTexture.GetTexture(urlMemoryImages + "/" + imgID);

        yield return uwrt.SendWebRequest();

        if (uwrt.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(uwrt.result);

            Debug.Log(uwrt.error);
        }
        else
        {
            Texture2D texture = DownloadHandlerTexture.GetContent(uwrt);
            processTexture(texture);
        }
    }
}
