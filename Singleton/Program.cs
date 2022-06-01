using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //CustomerManager customerManager = new CustomerManager();
            // yukarıdaki şekilde oluşturamıyoruz.

            var customerManager = CustomerManager.CreateAsSingleton();
            //Bu şekilde nesnemizi oluşturuyoruz.
            customerManager.Save();
            // bu şekilde kullanıyoruz.

        }
    }
    class CustomerManager
        // sadece işlem yapan bir class'ımız var
    {
        private static CustomerManager _customerManager;
        static object _lockerObject = new object();
        private CustomerManager()
        {
            // Dış erişimi engelliyoruz. 
        }
        public static CustomerManager CreateAsSingleton()
        {
            // Bu metodun içinde eğer CustomerManager nesnesinden daha önce oluşturulmuşu varsa 
            // biz oluşturulmuşu vericez, yoksa yeni birtane oluşturup onu veceğiz.
            //if (_customerManager==null)
            //nesne daha önce oluşturulmamış mı diye kontrol ediyoruz.
            //  {
            //   _customerManager = new CustomerManager();
            //oluşturulmamış ise oluşturuyoruz.
            // }
            //return _customerManager;
            // oluşturulmuş ise oluşturulmuşu döndür diyoruz.

            //***Single Line ile yazımı aşağıdaki şekildedir.***

            //return _customerManager ?? (_customerManager = new CustomerManager());
            //defensive programming ile
            lock (_lockerObject)
            {
                if (_customerManager ==null)
                {
                    _customerManager = new CustomerManager();
                }
            }  
            return _customerManager;
        }
        public void Save()
            // public static void olarak oluşturulmamalıdır.
        {
            Console.WriteLine("Saved!");
        }

    }
}
/* ----Singleton-----
 * Bir nesne örneğinden sadece bir kere üretilip ve bu nesneyi her zaman kullanmayı amaçlayan bir patterndir.
 * Gerçek hayat uygulamalarında bir nesnenin ve örnek değerinin bir çok kullanıcı tarafından değiştiği zaman aynı şekilde
 * kullanılmasını amaçlar. Bir websitesine anlık giren kullanıcı sayısını tutmak istiyoruz ve herkesin bunu okumasını istiyoruz.
 * En büyük hedeflerden bir tanesi bir nesnenin state'inin kontrol edilmesidir. 
 * Bir nesne örneğini katmanlar arasında geçerken sadece işlem yapıyorsa singleton kullanılmalıdır. Business katmanında ki bir işlem gibi.
 * NE Zaman kullanmamalıyız?
 * Singleton nesnesi her zaman sabit kalır. Dolayısıyla singleton nesnesini herkes kullanacak mı?
 * Nadir kullanılacak mı ? sorularına cevap vermelildir.
 * ---Eğer Bir nesneyi aynı anda iki kullanıcı isterse ve nesne henüz üretilmediyse nesnenin örneğini biri üretmeden 
 * diğeride aynı şekilde üretmek isterse, o nesneden iki adet oluşur. Yani aynı anda iki kullanıcı üretmek isterse 2 adet oluşur.
 * Bunuda defensive programmingle engelleyebiliriz.
 */
