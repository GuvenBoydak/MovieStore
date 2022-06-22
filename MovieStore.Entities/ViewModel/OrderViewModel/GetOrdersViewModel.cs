using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.Entities.ViewModel.OrderViewModel
{
    public class GetOrdersViewModel
    {
        public string FullName { get; set; }

        public IReadOnlyCollection<string> Movies { get; set; }

        public IReadOnlyCollection<string> Price { get; set; }

        public IReadOnlyCollection<string> OrderDate { get; set; }
    }
}
