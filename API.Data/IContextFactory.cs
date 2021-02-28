using System;
using System.Collections.Generic;
using System.Text;

namespace API.Data
{
    public interface IContextFactory
    {
        IContextDb GetInstance();
    }
}
