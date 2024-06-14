using CleanCode.Comments;
using System;
using System.Collections.Generic;

namespace CleanCode.OutputParameters
{
    public class OutputParameters
    {

        public class GetCustomersResult
        {
            public IEnumerable<Customer> Customers { get; set; }
            public int TotalCount { get; set; }
        }
        
        public void DisplayCustomers()
        {
            int pageIndex = 1;
            var result = GetCustomers(pageIndex);

            Console.WriteLine("Total customers: " + result.TotalCount);
            foreach (var c in result.Customer)
                Console.WriteLine(c);
        }

        public Tuple<<IEnumerable<Customer>, int> GetCustomers(int pageIndex)
        {
            var totalCount = 100;
            return new GetCustomersResult() { Item = new List<Customer>(), Item2 = totalCount}
        }
    }
}
