using CqrsSample.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CqrsSample.Queries;

public class GetAllPersonQuery:IRequest<List<GetAllPersonResponse>>
{
    
}

public class GetAllPersonResponse
{
    public long Id { get; set; }
    public string Name { get; set; }
}

public class GetAllPersonQueryHandler : IRequestHandler<GetAllPersonQuery, List<GetAllPersonResponse>>
{
    private readonly TestDbContext _dbContext;

    public GetAllPersonQueryHandler(TestDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<GetAllPersonResponse>> Handle(GetAllPersonQuery request, CancellationToken cancellationToken)
    {
        return await _dbContext.Persons.Select(person => new GetAllPersonResponse()
        {
            Id = person.Id,
            Name = person.Name
        }).ToListAsync(cancellationToken);
    }
}