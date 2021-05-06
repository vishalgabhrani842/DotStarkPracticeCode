using System.Runtime.Serialization;

namespace WebApiTest.Models
{
    [DataContract]
    public class ApiResponseModel<T> where T : class
    {
        [DataMember]
        public int StatusCode { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string Message { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public T Result { get; set; }

        public ApiResponseModel(int statusCode, string message = "", T result = null)
        {
            this.StatusCode = statusCode;
            this.Message = message;
            this.Result = result;
        }
    }
}
