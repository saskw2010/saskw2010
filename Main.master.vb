Imports eZee.Services
Imports eZee.Web
Imports System
Imports System.Collections.Generic
Imports System.Globalization
Imports System.Linq
Imports System.Reflection
Imports System.Text.RegularExpressions
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.HtmlControls
Imports System.Web.UI.WebControls


Partial Public Class Main
    Inherits Global.System.Web.UI.MasterPage

    Public Shared MicrosoftJavaScript() As String = New String() {"MicrosoftAjax.js", "MicrosoftAjaxWebForms.js"}

    Shared Sub New()
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
        If AquariumExtenderBase.EnableCombinedScript Then
            sm.EnableScriptLocalization = false
        End If
        Dim pageCssClass = (Page.GetType().Name + " Loading")
        Dim p = Page.GetType().GetProperty("CssClass")
        If (Not (p) Is Nothing) Then
            Dim cssClassName = CType(p.GetValue(Page, Nothing),String)
            If Not (String.IsNullOrEmpty(pageCssClass)) Then
                pageCssClass = (pageCssClass + " ")
            End If
            pageCssClass = (pageCssClass + cssClassName)
        End If
        If Not (pageCssClass.Contains("Wide")) Then
            pageCssClass = (pageCssClass + " Standard")
        End If
        Dim c = CType(Page.Form.Controls(0),LiteralControl)
        If ((Not (c) Is Nothing) AndAlso Not (String.IsNullOrEmpty(pageCssClass))) Then
            c.Text = Regex.Replace(c.Text, "<div>", String.Format("<div class=""{0}"">", pageCssClass))
        End If
        c = CType(PageContentPlaceHolder.Controls(0),LiteralControl)
    End Sub

    Protected Sub Page_PreRender(ByVal sender As Object, ByVal e As EventArgs)
        ApplicationServices.RegisterCssLinks(Page)
    End Sub
End Class
