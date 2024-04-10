using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wpf_TechMarketMangement.Models
{
    internal class DataProvider
    {
        // Singleton pattern
        // This class is used to connect to the database
        //how to use: DataProvider.Ins.DB
        private static DataProvider _ins;
        public static DataProvider Ins //create a new instance of the database context
        {
            get
            {
                if (_ins == null)
                    _ins = new DataProvider();
                return _ins;
            }
            set
            {
                _ins = value;
            }
        }
        public TechMarketManagementEntities DB { get; set; }
        public DataProvider()
        {
            DB = new TechMarketManagementEntities();  // Create a new instance of the database context
        }
    }
}
