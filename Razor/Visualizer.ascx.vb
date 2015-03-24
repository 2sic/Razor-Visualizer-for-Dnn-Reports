Imports DotNetNuke.Web.Razor
Imports DotNetNuke.Entities.Modules
Imports System.Collections.Generic
Imports DotNetNuke.Security
Imports DotNetNuke.Modules.Reports.Visualizers


Namespace DotNetNuke.Modules.Reports.Visualizers.Razor
    Partial Class Visualizer
        Inherits VisualizerControlBase

        Private Class RazorReportHost
            Inherits RazorModuleBase

            Protected Overrides ReadOnly Property RazorScriptFile As String
                Get
                    Dim script As String = TryCast (Me.ModuleContext.Settings.Item ("ScriptFile"), String)
                    If Not String.IsNullOrEmpty (script) Then
                        Return String.Format ("~/DesktopModules/RazorModules/RazorHost/Scripts/{0}", script)
                    End If
                    Return String.Empty
                End Get
            End Property

        End Class

        Private RazorHost As RazorReportHost

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load

            ParentModule.Actions.Add(Me.ParentModule.ModuleContext.GetNextActionID, Localization.GetString("EditContent.Action", Me.LocalResourceFile), _
                                      "AddContent.Action", "", "edit.gif", Me.ParentModule.EditUrl("EditRazorScript"), False, SecurityAccessLevel.Host, True, False)
            RazorHost = New RazorReportHost
            Me.Controls.Add(RazorHost)
            RazorHost.ModuleContext.Configuration = Me.ParentModule.ModuleConfiguration
            DataBind()
        End Sub

        Public Overrides Sub DataBind()
            If Me.ValidateDataSource AndAlso Me.ValidateResults() Then
                HttpContext.Current.Items(ModuleController.CacheKey(TabModuleId) + "_razor") = ReportResults
            End If
        End Sub
    End Class
End Namespace