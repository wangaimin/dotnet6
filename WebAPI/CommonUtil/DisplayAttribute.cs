namespace CommonUtil;


public class DisplayAttribute : Attribute
{
    private bool _display;

    public bool Display
    {
        get { return _display; }
        set { _display = value; }
    }

    public DisplayAttribute(bool display)
    {
        this._display = display;
    }
}