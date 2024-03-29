﻿using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using SimpleInjector;

namespace CompositionRoot
{
    public static class RootBindings
    {
        public static void Bind(Container container)
        {
            BindCqrsServices(container);

            //Qui tutti i nostri servizi custom
            container.Register<DomainModel.CQRS.Services.ISalvaDomanda,
                Persistence.MongoDB.SalvaDomanda>();
        }

        private static void BindCqrsServices(Container container)
        {
            var assemblies = new Assembly[]
            {
                typeof(DomainModel.CQRS.Queries.GetIntSum.GetIntSumQuery).Assembly
            };

            // The following two lines perform the batch registration by using
            // the great generics support provided by SimpleInjector.
            container.Register(typeof(CQRS.Commands.ICommandHandler<>), assemblies);
            container.Register(typeof(CQRS.Queries.IQueryHandler<,>), assemblies);

            //The following line performs the batch registration of the command notifiers
            container.Collection.Register(typeof(CQRS.Commands.Notifiers.ICommandNotifier<>), assemblies);
            container.RegisterDecorator(
                typeof(CQRS.Commands.ICommandHandler<>),
                typeof(CQRS.Commands.Notifiers.NotifyingCommandHandlerDecorator<>));

            //The following two lines perform the batch registration of the command authorizers
            container.Collection.Register(typeof(CQRS.Commands.Authorizers.ICommandAuthorizer<>), assemblies);
            container.RegisterDecorator(
                typeof(CQRS.Commands.ICommandHandler<>),
                typeof(CQRS.Commands.Authorizers.AuthorizingCommandHandlerDecorator<>));

            //The following two lines perform the batch registration of the query authorizers
            container.Collection.Register(typeof(CQRS.Queries.Authorizers.IQueryAuthorizer<,>), assemblies);
            container.RegisterDecorator(
                typeof(CQRS.Queries.IQueryHandler<,>),
                typeof(CQRS.Queries.Authorizers.AuthorizingQueryHandlerDecorator<,>));

            //The following two lines perform the batch registration of the command validators
            container.Collection.Register(typeof(CQRS.Commands.Validators.ICommandValidator<>), assemblies);
            container.RegisterDecorator(
                typeof(CQRS.Commands.ICommandHandler<>),
                typeof(CQRS.Commands.Validators.ValidatingCommandHandlerDecorator<>));

            //The following two lines perform the batch registration of the query validators
            container.Collection.Register(typeof(CQRS.Queries.Validators.IQueryValidator<,>), assemblies);
            container.RegisterDecorator(
                typeof(CQRS.Queries.IQueryHandler<,>),
                typeof(CQRS.Queries.Validators.ValidatingQueryHandlerDecorator<,>));

            container.RegisterDecorator(
                typeof(CQRS.Queries.IQueryHandler<,>),
                typeof(Logging.CQRS.QueryHandlerLogDecorator<,>));

            container.RegisterDecorator(
                typeof(CQRS.Commands.ICommandHandler<>),
                typeof(Logging.CQRS.CommandHandlerLogDecorator<>));
        }
    }
}
