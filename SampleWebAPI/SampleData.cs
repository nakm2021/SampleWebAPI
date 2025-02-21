using System.Collections.Generic;

namespace SampleWebAPI
{
    public class SampleData
    {
        public List<string> MyList { get; private set; }

        public SampleData()
        {
            MyList = new List<string>();
            for (int i = 0; i < 999; i++)
            {
                MyList.Add($"Item {i}");
            }
        }
    }
}
