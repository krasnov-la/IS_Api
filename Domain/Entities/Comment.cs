using System.Data;

namespace Domain.Entities;

public class Comment
{
    private readonly Guid _id;
    private Admin _admin;
    private string _message;
    public Guid Id => _id;
    public Admin Admin => _admin;
    public string Message => _message;

    private Comment(Admin admin, string message)
    {
        //_id = Guid.NewGuid();
        _admin = admin;
        _message = message;
    }

    public static Comment Create(Admin admin, string message)
    {
        return new Comment(admin, message);
    }

    public void Update(Admin admin, string message)
    {
        _admin = admin;
        _message = message;
    }
}