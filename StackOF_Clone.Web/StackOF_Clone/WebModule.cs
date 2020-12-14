using Autofac;
using NHibernate;
using StackOF_Clone.Core.Database.Contexts;
using StackOF_Clone.Core.Repositories;
using StackOF_Clone.Core.Services;
using StackOF_Clone.Core.UnitOfWorks;
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
            builder.RegisterType<QuestionRepository>().As<IQuestionRepository>().InstancePerLifetimeScope();
            builder.RegisterType<CommentRepository>().As<ICommentRepository>().InstancePerLifetimeScope();

            builder.RegisterType<ForumUnitOfWork>().As<IForumUnitOfWork>().InstancePerLifetimeScope();

            builder.RegisterType<MemberAccountService>().As<IMemberAccountService>().InstancePerLifetimeScope();
            builder.RegisterType<ForumService>().As<IForumService>().InstancePerLifetimeScope();

            builder.Register(s => FNHibernateContext.SessionOpen()).As<ISession>().InstancePerLifetimeScope();

            base.Load(builder);
        }
    }
}