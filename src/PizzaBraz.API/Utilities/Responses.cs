﻿using PizzaBraz.API.ViewModels;

namespace PizzaBraz.API.Utilities
{
    public static class Responses
    {
        public static ResultViewModel ApplicationErrorMessage()
        {
            return new ResultViewModel
            {
                Message = "Ocorreu algum erro interno na aplicação, por favor, tente novamente.",
                Success = false,
                Data = null
            };
        }

        public static ResultViewModel DomainErrorMessage(string message)
        {
            return new ResultViewModel
            {
                Message = message,
                Success = false,
                Data = null
            };
        }

        public static ResultViewModel DomainErrorMessage(string message, IReadOnlyCollection<string> errors)
        {
            return new ResultViewModel
            {
                Message = message,
                Success = false,
                Data = errors
            };
        }

        //public static ResultViewModel UnautohrizedErrorMessage()
        //{
        //    return new ResultViewModel
        //    {
        //        Message = "Login e/ou senha incorreto(a)(s)",
        //        Success = false,
        //        Data = null
        //    };
        //}
    }
}
