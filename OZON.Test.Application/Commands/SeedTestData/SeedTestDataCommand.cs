using MediatR;

namespace OZON.Test.Application.Commands.SeedTestData
{
    public class SeedTestDataCommand : IRequest<Unit>
    {
        public readonly int EmployeeCount;
        public SeedTestDataCommand(int employeeCount) => EmployeeCount = employeeCount;
    }
}