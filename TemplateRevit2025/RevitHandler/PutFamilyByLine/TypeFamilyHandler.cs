using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TemplateRevit2025.Core;
using TemplateRevit2025.View.PutFamilyByLine;
using MediatR;
using TemplateRevit2025.Mediator.PutFamilyByLine;
using TemplateRevit2025.ViewModel.PutFamilyByLine;

namespace TemplateRevit2025.RevitHandler.PutFamilyByLine
{
    public class TypeFamilyHandler : ExternalEventHandler
    {
        private FamilyVM familySelected;
        public TypeFamilyHandler(Window window, System.Windows.Controls.UserControl userControl,
            string nameHandler) : base(window, userControl, nameHandler)
        {

        }

        public override void Execute(UIApplication app)
        {
            var data = familySelected;


            throw new NotImplementedException();
        }

        public Task<bool> Handle(FamilySend request, CancellationToken cancellationToken)
        {
            familySelected = request.FamilyChoose;
            return Task.FromResult(true);
        }
    }
}
