namespace LegacyApp;

public class ClientRepositoryWrapper : IClientRepository
{
    private readonly ClientRepository _clientRepository = new ClientRepository(); // Legacy dependency

    public Client GetById(int clientId)
    {
        return _clientRepository.GetById(clientId);
    }

}
