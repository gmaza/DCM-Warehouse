﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DCMW.Common.Models
{
    public class Result
    {

        public Result(bool isSuccess, string message)
        {
            IsSuccess = isSuccess;
            Message = message;
        }

        public static Result CreateSuccessReqest(string message = "ოპერაცია წარმატებით შესრულდა")
        {
            return new Result(true, message);
        }

        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }

    public class Result<T> : Result
    {
        public T Data { get; set; }

        public Result(bool isSuccess, string message, T data) : base(isSuccess, message)
        {
            Data = data;
        }

        public static Result<T> CreateSuccessReqest(T data, string message = "success")
        {
            return new Result<T>(true, message, data);
        }
    }
}
