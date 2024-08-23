namespace Domain.Entities;

public class Activity
{
    private readonly Guid _id = Guid.NewGuid();
    private string _name;
    private Admin _admin;
    private DateTime _start;
    private DateTime _finish;
    private Image _preview;
    private string _link;
    public string Name => _name;
    public Guid Id => _id;
    public Admin Admin => _admin;
    public DateTime Start => _start;
    public DateTime Finish => _finish;
    public Image Preview => _preview;
    public string Link => _link;

    private Activity(
        string name, 
        Admin admin, 
        DateTime start, 
        DateTime finish,
        Image preview,
        string link)
    {
        _name = name;
        _admin = admin;
        _start = start;
        _finish = finish;
        _preview = preview;
        _link = link; 
    }

    public static Activity Create(
        string name, 
        Admin admin, 
        DateTime start, 
        DateTime finish,
        Image preview,
        string link
    )
    {
        return new Activity(
            name,
            admin,
            start,
            finish,
            preview,
            link
        );
    }

    public void Update(
        Admin admin,
        string? newName = null, 
        DateTime? newStart = null, 
        DateTime? newFinish = null,
        Image? newPreview = null,
        string? newLink = null
    )
    {
        _admin = admin;
        if (newName is not null) _name = newName;
        if (newStart.HasValue) _start = newStart.Value;
        if (newFinish.HasValue) _finish = newFinish.Value;
        if (newPreview is not null) _preview = newPreview;
        if (newLink is not null) _link = newLink;
    }
}