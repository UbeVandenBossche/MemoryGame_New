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
        public void OnPointerDown(PointerEventData eventData)
        {

        }

        protected override void Model_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {

        }

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
