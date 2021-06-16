namespace WebApi.DatabaseServices
{
    interface IDatabaseLoginServices
    {
        public bool MatchLoginCreds(string username,string password);
        public int GetLogIdOfUSer(string username);
    }
}
