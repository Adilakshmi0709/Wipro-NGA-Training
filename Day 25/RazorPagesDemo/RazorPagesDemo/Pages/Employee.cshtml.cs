@page
@model RazorPagesDemo.Pages.EmployeeModel
@{
    ViewData["Title"] = "Employee Form";
}

<h2>Enter Employee Details</h2>

<form method="post">
    <label>Employee ID:</label>
    <input asp-for="Emp.EmpId" /><br />

    <label>First Name:</label>
    <input asp-for="Emp.FirstName" /><br />

    <label>Last Name:</label>
    <input asp-for="Emp.LastName" /><br />

    <label>City:</label>
    <input asp-for="Emp.City" /><br />

    <button type="submit">Submit</button>
</form>

@if (Model.IsSubmitted)
{
    <h3>Employee Details</h3>
    <p><b>ID:</b> @Model.Emp.EmpId</p>
    <p><b>Name:</b> @Model.Emp.FirstName @Model.Emp.LastName</p>
    <p><b>City:</b> @Model.Emp.City</p>
}
