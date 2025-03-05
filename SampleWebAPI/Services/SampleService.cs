using System.Diagnostics;

namespace SampleWebAPI.Services
{
    public class SampleService : ISampleService
    {
        private List<string> _myList;

        public SampleService()
        {
            _myList = new SampleData().MyList;
        }

        public List<string> MyList
        {
            get
            {
                if (_myList == null)
                {
                    _myList = new SampleData().MyList;
                }
                return _myList;
            }
        }

        public void AddData(string item)
        {
            try
            {
                _myList.Add(item);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                throw new Exception(ex.Message);
            }
        }

        public void DeleteData(int id)
        {
            try
            {
                _myList.RemoveAt(id);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                throw new Exception(ex.Message);
            }
        }

        public List<string> GetData()
        {
            try
            {
                return _myList;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                throw new Exception(ex.Message);
            }
        }

        public string GetDataById(int id)
        {
            try
            {
                return _myList[id];
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                throw new Exception(ex.Message);
            }

        }

        public void UpdateData(int id, string item)
        {
            try
            {
                _myList[id] = item;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                throw new Exception(ex.Message);
            }
        }
    }
}
