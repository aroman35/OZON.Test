using System.ComponentModel;

namespace OZON.Test.Domain.Entities.Enums
{
    public enum Departments
    {
        [Description("IT Department")]
        IT = 0,
        [Description("HR Department")]
        HR = 1,
        [Description("Finance Department")]
        Finance = 2,
        [Description("Law Department")]
        Law = 3
    }
}