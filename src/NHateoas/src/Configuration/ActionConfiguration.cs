﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using NHateoas.Dynamic.Interfaces;
using NHateoas.Dynamic.Strategies;
using NHateoas.Dynamic.StrategyBuilderFactories;
using NHateoas.Response;
using NHateoas.Routes;
using NHateoas.Routes.RouteBuilders.SimpleRoutesBuilder;
using NHateoas.Routes.RouteValueSubstitution;

namespace NHateoas.Configuration
{
    internal class ActionConfiguration : IActionConfiguration
    {
        private readonly Type _controllerType;
        private readonly MethodInfo _actionMethodInfo;
        private readonly List<MappingRule> _mappingRules = new List<MappingRule>();
        private IRoutesBuilder _routesBuilder = null;
        private IResponseTransformerFactory _responseTransformerFactory = null;
        private IStrategyBuilderFactory _strategyBuilderFactory;

        public ActionConfiguration(Type controllerType, MethodInfo actionMethodInfo)
        {
            _controllerType = controllerType;
            _actionMethodInfo = actionMethodInfo;
        }

        public void Configure()
        {
            CreateConcreteInstances();
        }

        public Type ControllerType
        {
            get { return _controllerType; }
        }

        public MethodInfo ActionMethodInfo
        {
            get { return _actionMethodInfo; }
        }

        public void AddMappingRule(MappingRule rule)
        {
            _mappingRules.Add(rule);
        }

        public IEnumerable<MappingRule> MappingRules
        {
            get { return _mappingRules; }
        }

        public IRoutesBuilder RoutesBuilder
        {
            get { return _routesBuilder; }
            set { _routesBuilder = value; }
        }

        public IResponseTransformerFactory ResponseTransformerFactory
        {
            get { return _responseTransformerFactory; }
            set { _responseTransformerFactory = value; }
        }

        public IStrategyBuilderFactory StrategyBuilderFactory
        {
            get { return _strategyBuilderFactory; }
        }

        protected virtual void CreateConcreteInstances()
        {
            _routesBuilder = new SimpleRoutesBuilder(this);
            _responseTransformerFactory = new ResponseTransformerFactory();
            _strategyBuilderFactory = new DefaultStrategyBuilderFactory();
        }

    }
}
