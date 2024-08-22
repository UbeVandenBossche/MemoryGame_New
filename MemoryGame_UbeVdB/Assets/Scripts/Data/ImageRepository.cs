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
    string urlMemoryImages = "http://localhost:80/MemoryGame/api/MemoryGame";

    public void ProcessImageIDs(Action<List<int>> processIDs)
    {
        StartCoroutine(GetImageIDs(processIDs));
    }

    private IEnumerator GetImageIDs(Action<List<int>> processIDs)
    {
        UnityWebRequest uwrids = UnityWebRequest.Get(urlMemoryImages);
        yield return uwrids;

        if (uwrids.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(uwrids.error);
        }
        else
        {
            string json = uwrids.downloadHandler.text;
            List<DBImages> images = JsonConvert.DeserializeObject<List<DBImages>>(json);
            
           // processIDs(ids);
        }
    }
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
