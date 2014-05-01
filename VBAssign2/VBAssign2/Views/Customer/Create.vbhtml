@ModelType VBAssign2.ViewModels.CustomerFull
@Code
    ViewData("Title") = "Create"
End Code

<h2>Create</h2>

@Using (Html.BeginForm()) 
    @Html.AntiForgeryToken()
    
    @<div class="form-horizontal">
        <h4>CustomerFull</h4>
        <hr />
        @Html.ValidationSummary(true)
        <div class="form-group">
            @Html.LabelFor(Function(model) model.Name, New With { .class = "control-label col-md-2" })
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.Name)
                @Html.ValidationMessageFor(Function(model) model.Name)
            </div>
        </div>

        <div class="form-group">
            @Html.LabelFor(Function(model) model.Email, New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.Email)
                @Html.ValidationMessageFor(Function(model) model.Email)
            </div>
        </div>

        <div class="form-group">
            @Html.LabelFor(Function(model) model.Phone, New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.Phone)
                @Html.ValidationMessageFor(Function(model) model.Phone)
            </div>
        </div>

        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <input type="submit" value="Create" class="btn btn-default" />
            </div>
        </div>
    </div>
End Using

<div>
    @Html.ActionLink("Back to List", "Index")
</div>

@Section Scripts 
    @Scripts.Render("~/bundles/jqueryval")
End Section
