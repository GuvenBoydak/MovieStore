﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.Core.CrossCuttingConcerns.Logging
{
    public interface ILoggerService
    {
        public void Write(string message);
    }
}
