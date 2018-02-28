﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace PolinomService_Host
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost host = new ServiceHost(typeof(REST_polynomials.PolinomService));
            host.Open();
            Console.WriteLine("Service Hosted Sucessfully");
            Console.Read();
        }
    }
}
