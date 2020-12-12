using Autofac;
using NHibernate;
using StackOF_Clone.Core.Database.Contexts;
using StackOF_Clone.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StackOF_Clone.Web
{
    public class WebModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<MemberAccountService>().As<IMemberAccountService>().InstancePerLifetimeScope();

            builder.Register(s => FNHibernateContext.SessionOpen()).As<ISession>().InstancePerLifetimeScope();

            base.Load(builder);
        }
    }
}