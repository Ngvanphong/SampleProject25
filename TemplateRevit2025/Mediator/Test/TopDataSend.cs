using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemplateRevit2025.Model.Test;

namespace TemplateRevit2025.Mediator.Test
{
    public class TopDataSend : IRequest<bool>
    {
        public InstanceCus Wall { set; get; }
        public InstanceCus Door { set;get; }

    }
}
