using System;
using itlapr.DAL.Core;

namespace itlapr.DAL.Entities
{
    public  class Professor : Person
    {
        public DateTime HireDate { get; set; }
    }
}
