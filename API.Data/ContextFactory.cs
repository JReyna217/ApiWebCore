using System;
using System.Collections.Generic;
using System.Text;

namespace API.Data
{
    public class ContextFactory : IContextFactory
    {
        public IContextDb GetInstance()
        {
            return new ContextDb();
        }
    }
}
