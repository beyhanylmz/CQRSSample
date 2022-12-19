using CqrsSample.Data;
using CqrsSample.Models;
using MediatR;

namespace CqrsSample.Commands;

public class CreatePersonCommand:IRequest<CreatePersonResponse>
{
    public string Name { get; set; }
}

public class CreatePersonResponse
{
    public bool IsSuccessfull { get; set; }
    public long PersonId { get; set; }
}

public class CreatePersonCommanHandler : IRequestHandler<CreatePersonCommand,CreatePersonResponse>
{
    private TestDbContext _dbContext;

    public CreatePersonCommanHandler(TestDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<CreatePersonResponse> Handle(CreatePersonCommand request, CancellationToken cancellationToken)
    {
        var p = new Person
        {
            Name = request.Name
        };
        
        await _dbContext.Persons.AddAsync(p, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return new CreatePersonResponse
        {
            IsSuccessfull = true,
            PersonId = p.Id
        };
    }
}