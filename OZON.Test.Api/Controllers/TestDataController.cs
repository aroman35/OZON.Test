using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OZON.Test.Application.Commands;
using OZON.Test.Application.Commands.SetBonuses;
using OZON.Test.Application.Queries.BiggestSalaryInDept;
using OZON.Test.Application.Queries.EmployeesWithMaxBonuses;
using OZON.Test.Application.Queries.EmployeesWithSameSalary;
using OZON.Test.Application.Queries.GetLeads;
using OZON.Test.Application.Queries.GetTeamComposition;
using OZON.Test.Domain.Entities.Abstractions;

namespace OZON.Test.Api.Controllers
{
    public class TestDataController : BaseController
    {
        [HttpGet("SameSalary")]
        public async Task<ActionResult<IDictionary<decimal, IEnumerable<IEmployee>>>> GetSameSalaryWorkers()
        {
            var result = await Mediator.Send(new EmployeesWithSameSalaryRequest());
            return Ok(result);
        }

        [HttpGet("BestSalary")]
        public async Task<ActionResult<IDictionary<string, IEnumerable<string>>>> GetBestSalary()
        {
            var result = await Mediator.Send(new BiggestSalaryInDeptRequest());
            return Ok(result);
        }

        [HttpGet("GetTeams")]
        public async Task<ActionResult> GetTeams()
        {
            var settings = new JsonSerializerSettings();
            settings.NullValueHandling = NullValueHandling.Ignore;

            
            var result = await Mediator.Send(new GetTeamCompositionRequest());
            var json = JsonConvert.SerializeObject(result, settings);
            return Ok(result);
        }

        [HttpGet("BestBonus")]
        public async Task<ActionResult<IDictionary<string, IEnumerable<string>>>> GetBestBonus()
        {
            var result = await Mediator.Send(new EmployeesWithMaxBonusesRequest());
            return Ok(result);
        }

        [HttpGet("GetLeads")]
        public async Task<ActionResult<IDictionary<int, string>>> GetTeamLeads()
        {
            var result = await Mediator.Send(new GetLeadsRequest());
            return Ok(result);
        }

        [HttpPatch("Team/{leadId}/SetBonuses/{year}")]
        public async Task<ActionResult> SetBonuses(int leadId, int year)
        {
            var result = await Mediator.Send(new SetBonusesRequest(year, leadId));
            return Ok();}
    }
}