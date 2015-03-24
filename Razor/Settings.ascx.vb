
Imports DotNetNuke.Modules.Reports.Extensions
Imports System.Collections.Generic
Imports DotNetNuke.Entities.Modules
Imports DotNetNuke.Security

Namespace DotNetNuke.Modules.Reports.Visualizers.Razor
    Partial Class Settings
        Inherits ReportsSettingsBase

        Private RazorSettings As RazorHost.Settings

        Protected Sub Page_Init (ByVal sender As Object, ByVal e As EventArgs) Handles Me.Init
            LoadRazorSettingsControl()
            EnsureEditScriptControlIsRegistered()
            System.Web.HttpContext.Current.Response.Write("Found: " + TypeName(RazorSettings))

        End Sub

        Public Overrides Sub LoadSettings (ByVal Settings As Dictionary(Of String, String))
            RazorSettings.LoadSettings()
        End Sub

        Public Overrides Sub SaveSettings (ByVal Settings As Dictionary(Of String, String))
            RazorSettings.UpdateSettings()
        End Sub

        Private Sub EnsureEditScriptControlIsRegistered()
            Dim moduleDefId As Integer = ParentModule.ModuleConfiguration.ModuleDefID
            If ModuleControlController.GetModuleControlByControlKey("EditRazorScript", moduleDefId) Is Nothing Then
                Dim m As ModuleControlInfo
                m = New ModuleControlInfo With {.ControlKey = "EditRazorScript", .ControlSrc = "DesktopModules/RazorModules/RazorHost/EditScript.ascx", .ControlTitle = "Edit Script", _
                    .ControlType = SecurityAccessLevel.Host, .ModuleDefID = moduleDefId}
                ModuleControlController.UpdateModuleControl(m)
            End If
        End Sub

        Private Sub LoadRazorSettingsControl()
            RazorSettings = CType(LoadControl("~/DesktopModules/RazorModules/RazorHost/Settings.ascx"), RazorHost.Settings)
            RazorSettings.ModuleConfiguration = ParentModule.ModuleConfiguration
            RazorSettings.LocalResourceFile = Me.LocalResourceFile
            Controls.Add (RazorSettings)
        End Sub
    End Class
End Namespace
