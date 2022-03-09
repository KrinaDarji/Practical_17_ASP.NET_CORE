using Practical_17.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practical_17.Contracts
{
    public interface IPersonRepository: IGenericRepository<Person>
    {
    }
}
