using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public class DeliveryMethodIdNotFoundException(int id) : NotFoundException($"No Delivery Method with{id} was found")
    {
    }
}
