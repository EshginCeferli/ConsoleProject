using System;

namespace Repository.Repositories.Exceptions
{
    public class NotFoundException :Exception
    {
        public NotFoundException(string message) : base(message) { }              

    }
}
