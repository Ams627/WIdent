using System;
using System.Security.Principal;
using System.DirectoryServices.AccountManagement;

class Program
{
    private static void Main()
    {
        var user = WindowsIdentity.GetCurrent().User.Value;
        Console.WriteLine($"{user}");
        var sid = UserPrincipal.Current.Sid.ToString();
        Console.WriteLine($"{sid}");
    }
}
