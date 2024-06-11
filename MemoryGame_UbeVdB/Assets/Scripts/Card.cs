using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Card : MonoBehaviour,  IPointerDownHandler
{
    [SerializeField] Animator _animator;
    public void OnPointerDown(PointerEventData eventData)
    {
        _animator.Play("Show");
    }

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AnimationStartHandler()
    {
        Debug.Log("start");
    }

    public void AnimationEndHandler()
    {
        Debug.Log("end");
    }
}
