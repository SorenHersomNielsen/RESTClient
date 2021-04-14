using System;
using System.Collections.Generic;
using System.Text;

namespace RESTClient
{
    public class Cola
    {
        public int Id { get; set; }
        public string brand { get; set; }
        public string producent { get; set; }

        public override string ToString()
        {
            return Id + " " +brand + " " + producent;
        }
    }
}
