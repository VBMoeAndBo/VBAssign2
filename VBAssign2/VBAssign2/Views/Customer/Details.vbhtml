@ModelType VBAssign2.ViewModels.CustomerFull
@Code
    ViewData("Title") = "Details"
End Code

<h2>Details</h2>

<div>
    <h4>Customer Details</h4>
    <hr />
    <dl class="dl-horizontal">
        <dt>
            @Html.DisplayNameFor(Function(model) model.Name)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Name)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.email)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.email)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.phone)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.phone)
        </dd>

        

    </dl>
</div>
<div class="display-label"><i>Orders</i></div>
@If Not IsNothing(Model.orders) Then
    @<div class="dl-horizontal">
        @For Each ord In Model.orders

                Dim order = ord
            @*@<div class="display-field"> *@
            
            @<dt> @Html.DisplayFor(Function(unused) ord.ordId) </dt>
            @<dd> @Html.DisplayFor(Function(unused) ord.ordDate) </dd>
            @<dd> @Html.ActionLink("Order Items", "../Order/Details", New With {.id = ord.ordId}) </dd>
         
            @<br />
        Next
    </div>
Else

    @<p> @Html.Label("No details found") </p>

End If
<p>
    @Html.ActionLink("Edit", "Edit", New With { .id = Model.cstId }) |
    @Html.ActionLink("Back to List", "Index")
</p>
