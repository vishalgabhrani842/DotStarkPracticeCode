using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiTest.Core
{
    public static class MessageStatus
    {
        public static string Success
        {
            get
            {
                return "Data Retreived Successfully !";
            }
            set { }
        }
        public static string Error
        {

            get
            {
                return "An Error Occurred !";
            }
            set { }
        }
        public static string Update
        {
            get
            {
                return "Data Update Successfully !";
            }
            set { }
        }

        public static string QuantityAvailable
        {
            get
            {
                return "Quantity is available for product {0}";
            }
        }
        
        public static string QuantityNotAvailable
        {
            get
            {
                return "Quantity is not available for product {0}";
            }
        }

        public static string ProductNotExist
        {
            get
            {
                return "Product does not exists";
            }
        }
    }
}
