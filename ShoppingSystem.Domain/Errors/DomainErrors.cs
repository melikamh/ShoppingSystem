using ShoppingSystem.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingSystem.Domain.Errors
{
    public static class DomainErrors
    {


        public static class FirstName
        {
            public static readonly Error Empty = new(
                "FirstName.Empty",
                "نام را وارد کنید");

            public static readonly Error TooLong = new(
                "FirstName.TooLong",
                "نام وارد شده معتبر نیست .");
        }

        public static class LastName
        {
            public static readonly Error Empty = new(
                "LastName.Empty",
                "نام خانوادگی را وارد کنید");

            public static readonly Error TooLong = new(
                "LastName.TooLong",
                "نام خانوادگی وارد شده معتبر نیست.");
        }


    }
}
