namespace WebApi.DatabaseServices
{
    interface IDatabaseRegisterServices 
    {
        public bool RegisterRecordsIfValid(RegisterModel registerModel);
    }
}
