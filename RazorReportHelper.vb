
Imports System.Runtime.CompilerServices
Imports DotNetNuke.Web.Razor
Imports DotNetNuke.Entities.Modules
Imports System.Web
Imports System.Data
Imports System.Collections.Generic
Imports DotNetNuke.Web.Razor.Helpers

Namespace DotNetNuke.Modules.Reports.Visualizers.Razor
    Public Module RazorReportHelper
        <Extension()> _
        Public Function ReportResults(ByVal Helper As DnnHelper) As DataTable
            Return CType(HttpContext.Current.Items(ModuleController.CacheKey(Helper.Module.TabModuleID) + "_razor"), DataTable)
        End Function
    End Module
End Namespace
