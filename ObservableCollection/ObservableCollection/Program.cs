using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObservableCollection
{
    class Program
    {
        static void Main(string[] args)
        {
            ObservableCollection<string> presidents = new ObservableCollection<string>
            {
                "Jimmy Carter",
                "Ronald Reagan",
                "George HW Bush"
            };
            presidents.CollectionChanged += OnCollectionChanged;

            presidents.Add("Bil Clinton");
            presidents.Remove("Jimmy Carter");

            foreach (string president in presidents)
            {
                Console.WriteLine(president);
            }
            Console.ReadKey();
        }

        static void OnCollectionChanged(object sender,
            NotifyCollectionChangedEventArgs e)
        {
            //
        }
    }
}
