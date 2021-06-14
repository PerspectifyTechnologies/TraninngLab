namespace WebApi.DatabaseModel
{
    interface IDatabaseRegisterServices 
    {
        public bool RecordExists(RegisterModel registerModel);
        public void RecordEntries(RegisterModel registerModel);
    }
}
