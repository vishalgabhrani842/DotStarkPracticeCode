using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebApiTest.Models;

namespace WebApiTest.Services
{
    public class BaseService
    {
        public virtual ServiceResponse<T> SetResultStatus<T>(T objData, string Message, bool IsSuccess) where T : class
        {
            ServiceResponse<T> objReturn = new ServiceResponse<T>();
            objReturn.Message = Message;
            objReturn.IsSuccess = IsSuccess;
            objReturn.Data = objData;

            return objReturn;
        }
    }
}
