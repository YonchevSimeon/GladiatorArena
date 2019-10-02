namespace GladiatorArena.Services
{
    using AutoMapper;
    using Data;

    public abstract class BaseService
    {
        protected readonly IMapper mapper;
        protected readonly GladiatorArenaDbContext context;

        public BaseService(IMapper mapper, GladiatorArenaDbContext context)
        {
            this.mapper = mapper;
            this.context = context;
        }
    }
}
