using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Application.Helpers
{
    public static class Helper
    {
        public static void CheckString(string value, string fieldName)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new Exception($"{fieldName} boş ola bilməz.");
        }

        public static void CheckPrice(double price)
        {
            if (price <= 0)
                throw new Exception("Qiymət 0-dan böyük olmalıdır.");
        }

        public static void CheckId(int id, string fieldName)
        {
            if (id <= 0)
                throw new Exception($"{fieldName} düzgün deyil.");
        }
    }
}
