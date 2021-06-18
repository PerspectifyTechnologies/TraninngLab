namespace WebApi.DatabaseServices
{
    interface IDatabaseLoginServices
    {
        public bool MatchLoginCreds(string username,string password, int refresh );
        public int GetLogIdOfUSer(string username);
    }
}
