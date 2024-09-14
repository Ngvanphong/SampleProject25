using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using TemplateRevit2025.ViewModel.PutFamilyByLine;

namespace TemplateRevit2025.Mediator.PutFamilyByLine
{
    public class FamilySend : IRequest<bool>
    {
       public  FamilyVM FamilyChoose { set; get; }

    }
}
