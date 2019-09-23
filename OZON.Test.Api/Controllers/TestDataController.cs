using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OZON.Test.Api.ViewDataModels;
using OZON.Test.Application.Commands;
using OZON.Test.Application.Queries.BiggestSalaryInDept;
using OZON.Test.Application.Queries.EmployeesWithMaxBonuses;
using OZON.Test.Application.Queries.EmployeesWithSameSalary;
using OZON.Test.Application.Queries.GetTeamComposition;
using OZON.Test.Domain.Entities.Abstractions;

namespace OZON.Test.Api.Controllers
{
    public class TestDataController : BaseController
    {
        [HttpGet("SetRandomBonuses")]
        public async Task<ActionResult> SeedData()
        {
            await Mediator.Send(new SetRandomBonuses());
            return Ok();
        }

        [HttpGet("SameSalary")]
        public async Task<ActionResult<IDictionary<decimal, IEnumerable<IEmployee>>>> GetSameSalaryWorkers()
        {
            var result = await Mediator.Send(new EmployeesWithSameSalaryRequest());
            return Ok(result);
        }

        [HttpGet("BestSalary")]
        public async Task<ActionResult<IDictionary<string, IEmployee>>> GetBestSalary()
        {
            var result = await Mediator.Send(new BiggestSalaryInDeptRequest());
            return Ok(result);
        }

        [HttpGet("GetTeams")]
        public async Task<ActionResult> GetTeams()
        {
            var result = await Mediator.Send(new GetTeamCompositionRequest());
            return Ok(result);
        }

        [HttpGet("BestBonus")]
        public async Task<ActionResult<List<EmployeeWithBestBonus>>> GetBestBonus()
        {
            var result = await Mediator.Send(new EmployeesWithMaxBonusesRequest());
            return Ok(result.Select(x => new EmployeeWithBestBonus(x.Key, x.Value)).ToList());
        }
    }
}