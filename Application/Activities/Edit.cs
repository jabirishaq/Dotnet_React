using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Domain;
using MediatR;
using Persistence;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Application.Activities
{
    public class Edit
    {
        public class Command : IRequest<Unit> // doesnt return but query does
        {
            public Activity Activity { get; set; }
        }
    public class Handler : IRequestHandler<Command, Unit>
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public Handler(DataContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
        {
            var activity = await _context.Activities.FindAsync(request.Activity.Id);

            //activity.Title = request.Activity.Title ?? activity.Title; // it is without Mapper

            _mapper.Map(request.Activity, activity);

            await _context.SaveChangesAsync();

            return Unit.Value;

        }
    }
}
}