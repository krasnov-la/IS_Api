namespace Domain.Entities;

public class Activity
{
    private readonly Guid _id = Guid.NewGuid();
    private string _name;
    private Admin _admin;
    private DateTime _start;
    private DateTime _finish;
    private Image _preview;
    public string Name => _name;
    public Guid Id => _id;
    public Admin Admin => _admin;
    public DateTime Start => _start;
    public DateTime Finish => _finish;
    public Image Preview => _preview;

    private Activity(
        string name, 
        Admin admin, 
        DateTime start, 
        DateTime finish,
        Image preview)
    {
        _name = name;
        _admin = admin;
        _start = start;
        _finish = finish;
        _preview = preview;   
    }

    public static Activity Create(
        string name, 
        Admin admin, 
        DateTime start, 
        DateTime finish,
        Image preview
    )
    {
        return new Activity(
            name,
            admin,
            start,
            finish,
            preview
        );
    }

    public void Update(
        Admin admin,
        string? newName = null, 
        DateTime? newStart = null, 
        DateTime? newFinish = null,
        Image? newPreview = null
    )
    {
        _admin = admin;
        if (newName is not null) _name = newName;
        if (newStart.HasValue) _start = newStart.Value;
        if (newFinish.HasValue) _finish = newFinish.Value;
        if (newPreview is not null) _preview = newPreview;
    }
}