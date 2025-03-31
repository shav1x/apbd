using System;

namespace LegacyApp
{
    public class UserService : IUserService
    {
        private readonly IClientRepository _clientRepository;
        private readonly IUserCreditService _userCreditService;
        private readonly IUserDataAccess _userDataAccess;
        
        public UserService(IClientRepository clientRepository, IUserCreditService userCreditService, IUserDataAccess userDataAccess)
        {
            _clientRepository = clientRepository;
            _userCreditService = userCreditService;
            _userDataAccess = userDataAccess;
        }
        
        public UserService()
        {
            _clientRepository = new ClientRepositoryWrapper();
            _userCreditService = new UserCreditServiceWrapper();
            _userDataAccess = new UserDataAccessWrapper();
        }


        public bool AddUser(string firstName, string lastName, string email, DateTime dateOfBirth, int clientId)
        {
            if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName))
            {
                return false;
            }

            if (!email.Contains("@") || !email.Contains("."))
            {
                return false;
            }

            int age = CalculateAge(dateOfBirth);
            if (age < 21)
            {
                return false;
            }

            var client = _clientRepository.GetById(clientId);
            if (client == null) return false;

            var user = new User
            {
                Client = client,
                DateOfBirth = dateOfBirth,
                EmailAddress = email,
                FirstName = firstName,
                LastName = lastName
            };

            if (client.Type == "VeryImportantClient")
            {
                user.HasCreditLimit = false;
            }
            else if (client.Type == "ImportantClient")
            {
                user.HasCreditLimit = true;
                int creditLimit = _userCreditService.GetCreditLimit(user.LastName, user.DateOfBirth);
                user.CreditLimit = creditLimit * 2;
            }
            else
            {
                user.HasCreditLimit = true;
                int creditLimit = _userCreditService.GetCreditLimit(user.LastName, user.DateOfBirth);
                user.CreditLimit = creditLimit;
            }

            if (user.HasCreditLimit && user.CreditLimit < 500)
            {
                return false;
            }

            _userDataAccess.AddUser(user);
            return true;
        }

        private int CalculateAge(DateTime dateOfBirth)
        {
            var now = DateTime.Now;
            int age = now.Year - dateOfBirth.Year;
            if (now.Month < dateOfBirth.Month || (now.Month == dateOfBirth.Month && now.Day < dateOfBirth.Day))
            {
                age--;
            }
            return age;
        }
    }
}