using System;
using System.Security.Principal;
using System.DirectoryServices.AccountManagement;
using System.IO;
using System.Security.AccessControl;

class Program
{
    private static void Main()
    {
        var user = WindowsIdentity.GetCurrent().User.Value;
        Console.WriteLine($"{user}");
        //var sid = UserPrincipal.Current.Sid.ToString();
        //Console.WriteLine($"{sid}");

        var filename = @"c:\windows\system32\notepad.exe";
        var owner = GetFileOwner(filename);
        Console.WriteLine($"{owner}");
    }

    /// <summary>
    /// Get the Windows account name of the owner of a file:
    /// </summary>
    /// <param name="filename">The name of the file</param>
    /// <returns>The Windows account name</returns>
    private static string GetFileOwner(string filename)
    {
        FileSecurity fileSecurity = File.GetAccessControl(filename);
        IdentityReference identityReference = fileSecurity.GetOwner(typeof(SecurityIdentifier));
        NTAccount ntAccount = identityReference.Translate(typeof(NTAccount)) as NTAccount;
        return ntAccount.Value;
    }



}
