using System.Data;

namespace ProWPF.StoreDatabase
{
    public class StoreDbDataSet
    {
        public DataTable GetProducts() => ReadDataSet().Tables[0];

        public DataSet GetCategoriesAndProducts() => ReadDataSet();

        internal static DataSet ReadDataSet()
        {
            DataSet ds = new DataSet();
            ds.ReadXmlSchema("StoreDatabase\\store.xsd");
            ds.ReadXml("StoreDatabase\\store.xml");
            return ds;
        }
    }
}