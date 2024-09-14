﻿using MediatR;
using TemplateRevit2025.Mediator.PutFamilyByLine;
using UserControl = System.Windows.Controls.UserControl;

namespace TemplateRevit2025.View.PutFamilyByLine;

public partial class Bottom : UserControl, IRequestHandler<FamilySend, bool>
{
    public Bottom()
    {
        InitializeComponent();
    }

    public Task<bool> Handle(FamilySend request, CancellationToken cancellationToken)
    {
        var data = request.FamilyChoose;
        return Task.FromResult(true);
    }
}