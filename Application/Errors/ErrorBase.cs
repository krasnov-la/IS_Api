using FluentResults;

namespace Application.Errors;

public class ErrorBase : Error
{
    public ErrorBase(
        int status, 
        string detail) : 
        base()
        {  
            Metadata.Add("status", status);   
            Metadata.Add("detail", detail);     
        }

    public int Status => (int)Metadata["status"]; 
    public string Detail => (string)Metadata["detail"];
}