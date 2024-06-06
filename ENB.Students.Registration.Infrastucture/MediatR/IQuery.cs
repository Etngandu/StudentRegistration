﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENB.Students.Registration.Infrastucture
{
    public interface IQuery<out TResponse> : IRequest<TResponse>
    {
    }
}
