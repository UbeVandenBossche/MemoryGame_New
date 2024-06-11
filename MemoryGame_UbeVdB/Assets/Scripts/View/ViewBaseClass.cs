using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public abstract class ViewBaseClass<T> : MonoBehaviour where T : class, INotifyPropertyChanged
{
    [SerializeField] private T _model;
    public T Model
    {
        get { return _model; }
        set 
        {
            
            if(_model == value)
                return;
            if(null != _model)
                Model.PropertyChanged -= Model_PropertyChanged;

            _model = value;
            Model.PropertyChanged += Model_PropertyChanged;
        }
    }

    protected abstract void Model_PropertyChanged(object sender, PropertyChangedEventArgs e);
   
    
}
