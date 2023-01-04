Setting setting = Setting.GetInstance();
Console.WriteLine(setting.Value);

class Setting
{
    private static Setting _setting = null;

    public int Value = 0;

    private Setting()
    {
    }

    public static Setting GetInstance()
    {
        if (_setting == null)
        {
            _setting = new Setting();
        }

        return _setting;
    }
}