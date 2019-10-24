using System.Collections.Generic;

namespace DataInfo
{
    [System.Serializable]
    public class Data
    {
        public string Name;
        public string PhoneNumber;
        public string Email;
        public int cellNumber = 0;
    }

    public class DataList
    {
       public Data[] datas;
    }
}