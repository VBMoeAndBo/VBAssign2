@ModelType VBAssign2.ViewModels.CustomerFull
@Code
    ViewData("Title") = "Edit"
End Code

<h2>Edit</h2>

@Using (Html.BeginForm())
    @Html.AntiForgeryToken()
    
    @<div class="form-horizontal">
        <h4>CustomerFull</h4>
        <hr />
        @Html.ValidationSummary(true)
        @Html.HiddenFor(Function(model) model.cstId)

        <div class="form-group">
            @Html.LabelFor(Function(model) model.Name, New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.Name)
                @Html.ValidationMessageFor(Function(model) model.Name)
            </div>
        </div>

        <div class="form-group">
            @Html.LabelFor(Function(model) model.email, New With { .class = "control-label col-md-2" })
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.email)
                @Html.ValidationMessageFor(Function(model) model.email)
            </div>
        </div>

        <div class="form-group">
            @Html.LabelFor(Function(model) model.phone, New With { .class = "control-label col-md-2" })
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.phone)
                @Html.ValidationMessageFor(Function(model) model.phone)
            </div>
        </div>

        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <input type="submit" value="Save" class="btn btn-default" />
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
