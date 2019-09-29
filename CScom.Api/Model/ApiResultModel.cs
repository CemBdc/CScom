using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace CScom.Api.Model
{
    public class ApiResultModel<TData> where TData : class 
    {
        public int Code { get; set; }
        public string Message { get; set; }
        public TData Data { get; set; }
    }

    public class ApiResultModel
    {
        private object _data;
        public int Code { get; set; }
        public string Message { get; set; }
        public object Data
        {
            get { return _data; }
            set { _data = null; }
        }
        
    }
}
