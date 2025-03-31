using System;

namespace LegacyApp;

public class UserCreditServiceWrapper : IUserCreditService, IDisposable
{
    private readonly UserCreditService _userCreditService = new UserCreditService(); // Legacy dependency

    public int GetCreditLimit(string lastName, DateTime dateOfBirth)
    {
        return _userCreditService.GetCreditLimit(lastName, dateOfBirth);
    }

    public void Dispose()
    {
        _userCreditService.Dispose();
    }

}
