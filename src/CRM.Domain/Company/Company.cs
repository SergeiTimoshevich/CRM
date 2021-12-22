using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.Emailing;

namespace CRM.Company
{
    public class Company : FullAuditedAggregateRoot<Guid>
    {
        public string Name { get; set; }

        public Company()
        {
                
        }

        internal Company(Guid id, string name) : base(id)
        {
            SetName(name);
        }

        internal Company ChangeName( string name)
        {
            SetName(name);
            return this;
        }

        private void SetName(string name)
        {
            Name = Check.NotNullOrWhiteSpace(
                name,
                nameof(name)
            );
        }
    }
}
