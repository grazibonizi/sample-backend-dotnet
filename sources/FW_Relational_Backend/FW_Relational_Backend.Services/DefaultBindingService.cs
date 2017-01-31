using DryIoc;
using FW_Relational_Backend.Abstraction.DAL.Base;
using FW_Relational_Backend.Abstraction.DAL.UnitsOfWork;
using FW_Relational_Backend.Abstraction.Services;
using FW_Relational_Backend.DAL.UnitsOfWork;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FW_Relational_Backend.Services
{
    public class DefaultBindingService
        : IBindingService
    {
        private static Container container;

        public DefaultBindingService()
        {
            container = new Container();

            container.Register(
                typeof(IBindingService),
                typeof(DefaultBindingService),
                Reuse.Singleton
            );
            
            container.Register(
               typeof(ILogService),
               typeof(Log4NetService),
               Reuse.Singleton
           );

            container.RegisterDelegate<IDefaultUnitOfWork>(
                resolver =>
                    new DefaultUnitOfWork(
                        new DAL.Contexts.DefaultContext(ConfigurationManager
                            .ConnectionStrings["DefaultConnection"]
                            .ConnectionString
                            )
                    ),
                Reuse.Transient,
                setup: Setup.With(allowDisposableTransient: true)
            );
        }

        public IEnumerable<T> ResolveAll<T>()
        {
            return container.Resolve<IEnumerable<T>>();
        }

        public T ResolveSingle<T>()
        {
            return container.Resolve<T>();
        }

        public T ResolveSingle<T>(object serviceKey)
        {
            return container.Resolve<T>(serviceKey);
        }

        public Container GetContainer()
        {
            return container;
        }
    }
}
