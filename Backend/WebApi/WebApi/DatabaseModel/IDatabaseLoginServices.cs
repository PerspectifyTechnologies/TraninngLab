namespace WebApi.DatabaseModel
{
    interface IDatabaseLoginServices
    {
        public bool LoginMatchCreds(string username,string password);
    }
}
