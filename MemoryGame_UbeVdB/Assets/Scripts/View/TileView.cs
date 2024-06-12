using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.EventSystems;
using Memory.Model;


namespace Memory.View
{
    public class TileView : ViewBaseClass<Tile>, IPointerDownHandler
    {
        [SerializeField] Animator _animator;
        public MeshRenderer CardFrontRenderer;

        void Start()
        {
           // _animator = GetComponent<Animator>();
            //CardFrontRenderer = GetComponent<MeshRenderer>();
            AddEvents();
        }
        private void AddEvents()
        {
            for (int i = 0; i < _animator.runtimeAnimatorController.animationClips.Length; i++)
            {
                AnimationClip clip = _animator.runtimeAnimatorController.animationClips[i];

                AnimationEvent animationEndEvent = new AnimationEvent();
                animationEndEvent.time = clip.length;
                animationEndEvent.functionName = "AnimationEndHandler";
                animationEndEvent.stringParameter = clip.name;

                clip.AddEvent(animationEndEvent);
            }
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            Model.Board.State.AddPreview(Model);
        }

        protected override void Model_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            //if (e.PropertyName == "MemoryCardID")
            //    return;
            Debug.Log(e.PropertyName);
            Debug.Log(nameof(Model.State));
            if (e.PropertyName.Equals(nameof(Model.State)))
            {
                StartAnimation();
            }
            else if (e.PropertyName.Equals(nameof(Model.MemoryCardID)))
            {
                LoadFront();
            }
        }
        private void LoadFront()
        {
            //ImageRepository.Instance.GetProcessTexture(Model.MemoryCardID, LoadFront);
        }

        private void LoadFront(Texture2D texture2D)
        {
            //CardFrontRenderer.material.mainTexture = texture2D;
        }



        // Update is called once per frame
        void Update()
        {

        }

        private void StartAnimation()
        {
            if (Model.State.TileState == Memory.Model.States.TileStates.Hidden)
            {
                _animator.Play("Hide");
            }
            else
            {
                _animator.Play("Show");
            }
        }

        public void AnimationEndHandler(string name)
        {
            Model.Board.State.TileAnimationEnded(Model);
        }

       
    }
}
