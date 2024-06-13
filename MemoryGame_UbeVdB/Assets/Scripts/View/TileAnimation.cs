using Memory.View;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileAnimation : MonoBehaviour
{
    [SerializeField] TileView _tile;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AnimationEndHandler(string name)
    {
        _tile.AnimationEndHandler(name);
        Debug.Log(name);
    }
    public void AnimationStartHandler(string name)
    {

    }
}
