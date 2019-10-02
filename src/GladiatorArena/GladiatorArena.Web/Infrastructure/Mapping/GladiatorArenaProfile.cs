namespace GladiatorArena.Web.Infrastructure.Mapping
{
    using AutoMapper;
    using System;
    using System.Linq;
    using Utilities.Mapping;

    public class GladiatorArenaProfile : Profile
    {
        public GladiatorArenaProfile()
        {
            var allTypes = AppDomain
                .CurrentDomain
                .GetAssemblies()
                .Where(a => a.GetName().Name.Contains("GladiatorArena"))
                .SelectMany(a => a.GetTypes());

            allTypes
                .Where(t => t.IsClass &&
                            !t.IsAbstract &&
                            t.GetInterfaces()
                            .Where(i => i.IsGenericType)
                            .Select(i => i.GetGenericTypeDefinition())
                            .Contains(typeof(IMapFrom<>)))
                .Select(t => new
                {
                    Destination = t,
                    Source = t
                        .GetInterfaces()
                        .Where(i => i.IsGenericType)
                        .Select(i => new
                        {
                            Definition = i.GetGenericTypeDefinition(),
                            Arguments = i.GetGenericArguments()
                        })
                        .Where(i => i.Definition == typeof(IMapFrom<>))
                        .SelectMany(i => i.Arguments)
                        .First()
                })
                .ToList()
                .ForEach(mapping
                    => this.CreateMap(mapping.Source,
                                      mapping.Destination)
                                        .ReverseMap());

            allTypes
                .Where(t => t.IsClass &&
                            !t.IsAbstract &&
                            typeof(IHaveCustomMapping).IsAssignableFrom(t))
                .Select(Activator.CreateInstance)
                .Cast<IHaveCustomMapping>()
                .ToList()
                .ForEach(mapping => mapping.ConfigureMapping(this));
        }
    }
}
