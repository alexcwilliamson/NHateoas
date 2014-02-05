﻿using NHateoas.Dynamic.Interfaces;
using NHateoas.Response;
using NHateoas.Routes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NHateoas.Configuration
{
    internal interface IActionConfiguration
    {
        Type ControllerType { get; }

        MethodInfo ActionMethodInfo { get; }

        IEnumerable<MappingRule> MappingRules { get; }

        IRoutesBuilder RoutesBuilder { get; }

        IResponseTransformerFactory ResponseTransformerFactory { get; }

        IStrategyBuilderFactory StrategyBuilderFactory { get; }
    }
}
