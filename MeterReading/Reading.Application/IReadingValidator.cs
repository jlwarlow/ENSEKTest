using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reading.Application
{
    public interface IReadingValidator
    {
        Task<(bool valid, Entity.Reading reading)> Validate(string input);
    }
}
