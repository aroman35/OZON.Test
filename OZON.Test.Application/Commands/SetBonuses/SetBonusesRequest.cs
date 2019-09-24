using MediatR;

namespace OZON.Test.Application.Commands.SetBonuses
{
    public class SetBonusesRequest : IRequest
    {
        public readonly int LeadId;
        public readonly int Year;

        public SetBonusesRequest(int year, int leadId)
        {
            Year = year;
            LeadId = leadId;
        }
    }
}