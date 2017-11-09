using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuplicateCheckerRunner
{
    public interface IDataRepository
    {
        List<Car> Get();
        List<Item> GetComplex();
        List<string[]> GetAll();
        List<Item> LoadFromTable();
    }
}
