using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethod
{
    class Program
    {

        static void Main(string[] args)
        {
            //CustomerManager customerManager = new CustomerManager(new LoggerFactory());
            CustomerManager customerManager = new CustomerManager(new LoggerFactory2());
            customerManager.Save();


            Console.ReadLine();
        }

        public class LoggerFactory : ILoggerFactory
        // dediğimiz gibi classlar çıplak durmamalı
        {
            // logglama yapacak bir sınıf üretiyoruz
            public ILogger CreateLogger()
            {
                // burada bir iş geliştirip ablogger mı verelim başka bir logger mı verelim onu kontrol ederiz.
                // veritabanı mı oracle mı metin dosyasımı gibi.
                // fabrikanın logger'ını kontrol ederiz.
                return new AbLogger();
            }
        }
        public class LoggerFactory2 : ILoggerFactory
        {
            public ILogger CreateLogger()
            {

                return new Log4NetLogger();
            }
        }
        public interface ILoggerFactory
        {
            ILogger CreateLogger();
        }

        public interface ILogger
        {
            void Log();
        }
        public class AbLogger : ILogger
        {
            public void Log()
            {
                Console.WriteLine("Logged With AbLogger");
            }
        }
        public class Log4NetLogger : ILogger
        {
            public void Log()
            {
                Console.WriteLine("Logged With Log4NetLogger");
            }
        }
        public class CustomerManager
        {
            private ILoggerFactory _loggerFactory;
            //loggerfactory injection yapıyoruz.

            public CustomerManager(ILoggerFactory loggerFactory)
            {
                _loggerFactory = loggerFactory;
            }


            public void Save()
            {
                Console.WriteLine("Saved!");
                ILogger logger = _loggerFactory.CreateLogger();
                logger.Log();

                // ILogger logger = new AbLogger();
                // bir new yazıyorsak o nesneye bağımlı oluruz.
                // biz factory ile üretmek istiyoruz.
            }
        }

        /* FactoryMethod design pattern en çok kullanılan design pattern'lerdendir.
         * Amaç yazılımda değişimi kontrol altında tutmaktır.
         * Farklı tekniklerin implementasyonunu gerçekleştirecek bir yapıyı barındırır.
         * En temel olay bir fabrikamızın olmasıdır. 
         */

    }


}
