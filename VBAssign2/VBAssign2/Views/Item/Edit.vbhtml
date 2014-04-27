@ModelType VBAssign2.ViewModels.ItemFull
@Code
    ViewData("Title") = "Edit"
End Code

<h2>Edit</h2>

@Using (Html.BeginForm())
    @Html.AntiForgeryToken()
    
    @<div class="form-horizontal">
        <h4>ItemFull</h4>
        <hr />
        @Html.ValidationSummary(true)
        <div class="form-group">
            @Html.LabelFor(Function(model) model.itmId, New With { .class = "control-label col-md-2" })
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.itmId)
                @Html.ValidationMessageFor(Function(model) model.itmId)
            </div>
        </div>

        <div class="form-group">
            @Html.LabelFor(Function(model) model.name, New With { .class = "control-label col-md-2" })
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.name)
                @Html.ValidationMessageFor(Function(model) model.name)
            </div>
        </div>

        <div class="form-group">
            @Html.LabelFor(Function(model) model.brand, New With { .class = "control-label col-md-2" })
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.brand)
                @Html.ValidationMessageFor(Function(model) model.brand)
            </div>
        </div>

        <div class="form-group">
            @Html.LabelFor(Function(model) model.quantity, New With { .class = "control-label col-md-2" })
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.quantity)
                @Html.ValidationMessageFor(Function(model) model.quantity)
            </div>
        </div>

        <div class="form-group">
            @Html.LabelFor(Function(model) model.price, New With { .class = "control-label col-md-2" })
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.price)
                @Html.ValidationMessageFor(Function(model) model.price)
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
