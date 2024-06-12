using Memory.Models;
using Memory.Views;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using TMPro;
using UnityEngine;

public class PlayerView : ViewBaseClass<Player>
{
    public TextMeshProUGUI PlayerInfo;

    private string _minutesActive
    {
        get
        {
            int minsActive = (int)Model.ElapsedTime / 60;
            return minsActive < 10 ? $"0{minsActive}" : $"{minsActive}";
        }
    }

    private string _secondsActive
    {
        get
        {
            int secsActive = (int)Model.ElapsedTime % 60;
            return secsActive < 10 ? $"0{secsActive}" : $"{secsActive}";
        }
    }
    protected override void Model_PropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        PlayerInfo.text = $"{Model.Name}\nScore: {Model.Score}\n{_minutesActive}:{_secondsActive}";
        if (Model.IsActive)
        {
            PlayerInfo.color = Color.white;
        }
        else
        {
            PlayerInfo.color = Color.gray;
        }
    }

    private void Update()
    {
        if (!Model.IsActive)
        {
            return;
        }
        Model.ElapsedTime += Time.deltaTime;
    }
}
