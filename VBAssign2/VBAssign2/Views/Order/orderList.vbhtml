@ModelType IEnumerable(Of VBAssign2.ViewModels.OrderFull)
@Code
ViewData("Title") = "orderList"
End Code

<h2>orderList</h2>

<p>
    @Html.ActionLink("Create New", "Create")
</p>
<table class="table">
    <tr>
        <th>
            @Html.DisplayNameFor(Function(model) model.ordId)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.ordDate)
        </th>
        @*<th>
            @Html.DisplayNameFor(Function(model) model.customer.cstId)
        </th>*@
    </tr>

@For Each item In Model
    @<tr>
         <td>
             @Html.DisplayFor(Function(modelItem) item.ordId)
         </td>
         <td>
             @Html.DisplayFor(Function(modelItem) item.ordDate)
         </td>
        @*<td>
            @Html.DisplayFor(Function(modelItem) item.customer.cstId)
        </td>*@
        <td>
            @Html.ActionLink("Edit", "Edit", New With {.id = item.ordId }) |
            @Html.ActionLink("Details", "Details", New With {.id = item.ordId }) 
            @*@Html.ActionLink("Delete", "Delete", New With {.id = item.ordId })*@
        </td>
    </tr>
Next

</table>
