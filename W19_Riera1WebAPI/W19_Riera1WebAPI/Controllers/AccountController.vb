Imports System.Net
Imports System.Web.Http

Public Class AccountController
    Inherits ApiController

    ' GET api/<controller>
    Public Function GetValues() As IEnumerable(Of String)
        Return New String() {"value1", "value2"}
    End Function

    ' GET api/<controller>/5
    Public Function GetValue(ByVal id As Integer) As String
        Return "value"
    End Function

    ' POST api/<controller>
    Public Sub PostValue(<FromBody()> ByVal value As String)

    End Sub

    ' PUT api/<controller>/5
    Public Sub PutValue(ByVal id As Integer, <FromBody()> ByVal value As String)

    End Sub

    ' DELETE api/<controller>/5
    Public Sub DeleteValue(ByVal id As Integer)

    End Sub
    ' POST api/Account/Register
    <AllowAnonymous>
    <Route("Register")>
    Public Async Function Register(model As RegisterBindingModel) As Task(Of IHttpActionResult)
        If Not ModelState.IsValid Then
            Return BadRequest(ModelState)
        End If

        Dim user = New ApplicationUser() With {
                .UserName = model.Email,
                .Email = model.Email
            }

        Dim result As IdentityResult = Await UserManager.CreateAsync(user, model.Password)

        If Not result.Succeeded Then
            Return GetErrorResult(result)
        End If

        Return Ok()
    End Function
End Class

