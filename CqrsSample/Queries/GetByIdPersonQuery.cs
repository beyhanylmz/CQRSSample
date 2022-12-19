using CqrsSample.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CqrsSample.Queries;

public class GetByIdPersonQuery:IRequest<GetByIdPersonResponse>
{
    public long Id { get; set; }
}

public class GetByIdPersonResponse
{
    public long Id { get; set; }
    public string Name { get; set; }
}

public class GetByIdPersonQueryHandler : IRequestHandler<GetByIdPersonQuery, GetByIdPersonResponse>
{
    private readonly TestDbContext _dbContext;

    public GetByIdPersonQueryHandler(TestDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<GetByIdPersonResponse> Handle(GetByIdPersonQuery request, CancellationToken cancellationToken)
    {
        var person = await _dbContext.Persons.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken: cancellationToken);

        return person != null
            ? new GetByIdPersonResponse
            {
                Id = person.Id,
                Name = person.Name
            }
            : new GetByIdPersonResponse();
    }
}