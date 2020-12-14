using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.AspNet.Identity.Helpers;
using NHibernate.Tool.hbm2ddl;
using StackOF_Clone.Core.Database.Mappings;
using StackOF_Clone.Core.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackOF_Clone.Core.Database.Contexts
{
    public class FNHibernateContext
    {
        private static ISessionFactory _session;

        private static ISessionFactory CreateSession()
        {
            if (_session != null)
            {
                return _session;
            }

            // this assumes you are using the default Identity model of "ApplicationUser"
            var myEntities = new[] {
                typeof(ApplicationUser)
            };

            var connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();


            FluentConfiguration _config = Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2012.ConnectionString(connectionString))
                .Mappings(x => x.FluentMappings.AddFromAssemblyOf<QuestionMapping>())
                .Mappings(x => x.FluentMappings.AddFromAssemblyOf<CommentMapping>())
                .ExposeConfiguration(cfg =>
                {
                    cfg.AddDeserializedMapping(MappingHelper.GetIdentityMappings(myEntities), null);
                    new SchemaUpdate(cfg).Execute(false, true);
                });

            _session = _config.BuildSessionFactory();

            return _session;
        }

        public static ISession SessionOpen()
        {
            return CreateSession().OpenSession();
        }
    }
}
