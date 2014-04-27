@ModelType IEnumerable(Of VBAssign2.ViewModels.ItemFull)
@Code
ViewData("Title") = "Index"
End Code

<h2>Index</h2>

<p>
    @Html.ActionLink("Create New", "Create")
</p>
<table class="table">
    <tr>
        <th>
            @Html.DisplayNameFor(Function(model) model.itmId)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.name)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.brand)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.quantity)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.price)
        </th>
        <th></th>
    </tr>

@For Each item In Model
    @<tr>
        <td>
            @Html.DisplayFor(Function(modelItem) item.itmId)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.name)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.brand)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.quantity)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.price)
        </td>
        <td>
            @Html.ActionLink("Edit", "Edit", New With {.id = item.itmId}) |
            @Html.ActionLink("Details", "Details", New With {.id = item.itmId}) 
            @*@Html.ActionLink("Delete", "Delete", New With {.id = item.PrimaryKey})*@
        </td>
    </tr>
Next

</table>
