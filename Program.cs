using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using static RESTClient.RESTClient;

namespace RESTClient
{
    class Program
    {
        private const string BaseUri = "http://localhost:57059/api/Cola";
        static void Main(string[] args)
        {
            List<Cola> Records = GetList<Cola>(BaseUri).Result;
            Console.WriteLine("ALL: " + string.Join("\n", Records));
            try
            {
                Cola records = GetSingle<Cola>(BaseUri + "/1").Result;
                Console.WriteLine("GET by id: " + records);
            }
            catch (AggregateException ex)
            {
                ReadOnlyCollection<Exception> innerExceptions = ex.InnerExceptions;
                Exception exception = innerExceptions[0];
                Console.WriteLine(exception.Message);
            }

            Cola newRecords = new Cola { brand = "dr pepper", producent = "pepsi" };
            Cola c = Post<Cola, Cola>(BaseUri, newRecords).Result;
            Console.WriteLine("Added: " + c);

            Cola newValues = new Cola { Id = 3, brand = "cola-cola", producent = "cola-cola" };
            Cola updatedCola = Put<Cola, Cola>(BaseUri + "/" + c.Id, newValues).Result;
            Console.WriteLine("Updated: " + updatedCola);

            Cola deletedCar = Delete<Cola>(BaseUri + "/" + updatedCola.Id).Result;
            Console.WriteLine("Deleted: " + deletedCar);
        }
    }
}
