using Memory.Model;

public class Player : ModelBaseClass
{
    private string _name;
    private int _score;

    public string Name
    {
        get => _name;
        set
        {
            if (_name == value) return;
            _name = value;
            OnPropertyChanged();
        }
    }

    public int Score
    {
        get => _score;
        set
        {
            if (_score == value) return;
            _score = value;
            OnPropertyChanged();
        }
    }

    private bool _isActive;

    public bool IsActive
    {
        get => _isActive;
        set
        {
            if (_isActive == value) return;
            _isActive = value;
            OnPropertyChanged();
        }
    }

    private float _elapsedTime;
    public float ElapsedTime
    {
        get => _elapsedTime;
        set
        {
            if (_elapsedTime == value) return;
            _elapsedTime = value;
            OnPropertyChanged();
        }
    }
}
