namespace SampleWebAPI
{
    public interface ISampleService
    {
        public List<string> MyList { get; }
        List<string> GetData();
        string GetDataById(int id);
        void AddData(string item);
        void UpdateData(int id, string item);
        void DeleteData(int id);
    }
}
