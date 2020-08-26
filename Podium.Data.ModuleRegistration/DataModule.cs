using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Podium.Data.Abstractions;
using Podium.Data.Repositories;

namespace Podium.Data.ModuleRegistration
{
    public class DataModule : Module
    {
        public DataModule()
        {
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterType<UserDetailsRepository>()
                .As<IUserDetailsRepository>()
                .InstancePerLifetimeScope();

            builder
                .RegisterType<PropertyDetailsRepository>()
                .As<IPropertyDetailsRepository>()
                .InstancePerLifetimeScope();

            builder
                .RegisterType<ProductRepository>()
                .As<IProductRepository>()
                .InstancePerLifetimeScope();

            builder
                .RegisterType<LoanCalculationRepository>()
                .As<ILoanCalculationRepository>()
                .InstancePerLifetimeScope();
        }
    }
}