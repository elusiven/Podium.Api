using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Podium.Data.Primitives.Entities;
using Podium.Service.Abstractions;

namespace Podium.Service.ModuleRegistration
{
    public class ServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterType<UserDetailService>()
                .As<IUserDetailService>()
                .InstancePerLifetimeScope();

            builder
                .RegisterType<LoanCalculationService>()
                .As<ILoanCalculationService>()
                .InstancePerLifetimeScope();

            builder
                .RegisterType<ProductService>()
                .As<IProductService>()
                .InstancePerLifetimeScope();

            builder
                .RegisterType<FinanceCalculationsService>()
                .As<IFinanceCalculationsService>()
                .SingleInstance();

            builder
                .RegisterType<ValidationService>()
                .As<IValidationService>()
                .SingleInstance();
        }
    }
}