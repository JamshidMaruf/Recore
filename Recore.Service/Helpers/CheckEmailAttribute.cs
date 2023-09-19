

using Recore.Service.Exceptions;
using System.ComponentModel.DataAnnotations;
using System.Net.Mail;
using System.Text.RegularExpressions;

namespace Recore.Service.Helpers;

public class CheckEmailAttribute: ValidationAttribute
{
    public override bool IsValid(object value)
    {
        string email = value.ToString()
            ?? throw new CustomException(403, "Invalid email");
        string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";

        if (!Regex.IsMatch(email, pattern))
             throw new CustomException(403, "Invalid email"); 
        return true;
    }
}
