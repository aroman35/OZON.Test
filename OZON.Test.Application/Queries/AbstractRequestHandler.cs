using AutoMapper;
using MediatR;
using OZON.Test.Application.Exceptions;
using OZON.Test.Application.Infrastructure;

namespace OZON.Test.Application.Queries
{
    public abstract class AbstractRequestHandler
    {
        protected readonly IMediator _mediator;
        protected readonly IApplicationContext _context;
        protected readonly IMapper _mapper;

        protected AbstractRequestHandler(IApplicationContext context) =>
            _context = context ?? throw new EmptyServiceException(typeof(IApplicationContext));
        
        protected AbstractRequestHandler(IApplicationContext context, IMapper mapper) : this(context) =>
            _mapper = mapper ?? throw new EmptyServiceException(typeof(IMapper));

        protected AbstractRequestHandler(IApplicationContext context, IMapper mapper, IMediator mediator)
            : this(context, mapper) =>
            _mediator = mediator;
    }
}